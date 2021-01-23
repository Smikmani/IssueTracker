using Project1.Interfaces;
using Project1.ViewModel.IssueTable;
using Project1.ViewModel.Shared;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Project1.Data;
using Project1.Data.Entities;
using System.Linq;
using Microsoft.Extensions.Caching.Distributed;
using Project1.Extensions;
//using Microsoft.AspNetCore.Http.Extensions;
namespace Project1.Services
{
    public class IssueTableViewModelService : IIssuesTableViewModelService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IHttpContextAccessor _httpCtxAccessor;
        private readonly IDistributedCache _cache;

        public IssueTableViewModelService(ApplicationDbContext ctx,
                                          IHttpContextAccessor httpCtxAccessor,
                                          IDistributedCache cache)
        {
            _ctx = ctx;
            _httpCtxAccessor = httpCtxAccessor;
            _cache = cache;
        }

        public int ProjectId { get; set; }
        public async Task<IssueTableViewModel> GetIssueTableViewModel(IssueTableFilter filter, int currentPage)
        {
            var issueTableVM = new IssueTableViewModel();

            ProjectId = (int)_httpCtxAccessor.HttpContext.Session.GetInt32("projectId");

            issueTableVM.Issues = await GetIssues(filter, currentPage);
            issueTableVM.Types = await GetTypeSelectItems();
            issueTableVM.Status = await GetStatusSelectItems();
            foreach(var t in issueTableVM.Types)
            {
                if(t.Id == filter.TypeId)
                {
                    issueTableVM.SelectedType = t;
                    break;
                }
            }

            foreach(var s in issueTableVM.Status)
            {
                if(s.Id == filter.StatusId)
                {
                    issueTableVM.SelectedStatus = s;
                    break;
                }
            }

            return issueTableVM;
        }

        public async Task<List<IssueTableItemViewModel>> GetIssues(IssueTableFilter filter, int currentPage)
        {
            var skip = (currentPage - 1) * filter.PerPage;

            return await _ctx.Issues.Include(i => i.Type)
                                    .Include(i => i.Status)
                                    .Where(i => i.ProjectId == ProjectId && 
                                                (filter.TypeId == 0 || filter.TypeId == i.TypeId) && 
                                                (filter.StatusId == 0 || filter.StatusId == i.StatusId))
                                    .Select(i => new IssueTableItemViewModel
                                    {
                                        Id = i.Id,
                                        Name = i.Name,
                                        Type = i.Type,
                                        Status = i.Status,
                                        DueDate = i.DueDate
                                    })
                                    .Skip(skip)
                                    .Take(filter.PerPage)
                                    .ToListAsync();
                

        }

        public async Task<List<string>> GetPaginationUris(IssueTableFilter filter)
        {
            if (filter == null)
            {
                filter = new IssueTableFilter();
            }
            
            var dict = new Dictionary<string, string>();
            var res = new List<string>();

            dict.Add("Filter.PerPage", filter.PerPage.ToString());
            dict.Add("Filter.TypeId", filter.TypeId.ToString());
            dict.Add("Filter.StatusId", filter.StatusId.ToString());
            
            var query = QueryString.Create(dict).Value;
            var issueCount = await _ctx.Issues.Where(i => i.ProjectId == ProjectId &&
                                                          (filter.TypeId == 0 || filter.TypeId == i.TypeId) &&
                                                          (filter.StatusId == 0 || filter.StatusId == i.StatusId))
                                                    .CountAsync();

            var totalPages = issueCount % filter.PerPage == 0 ? issueCount / filter.PerPage : issueCount / filter.PerPage + 1;

            var req = _httpCtxAccessor.HttpContext.Request;
            for(int i=1; i<=totalPages; i++)
            {
                var uri = $"{req.Scheme}://{req.Host.ToUriComponent()}/IssuesTable{query}&CurrentPage={i}";
                res.Add(uri);
            }

            return res;
        }

        public async Task<List<SelectItem>> GetTypeSelectItems()
        {
            var typeItems = _cache.Get<List<SelectItem>>($"T{ProjectId}");

            if (typeItems == null)
            {
                typeItems = await _ctx.Types
                                      .Where(t => (t.ProjectId == ProjectId) || (t.ProjectId == 0))
                                      .Select(t => new SelectItem { Id = t.Id, Name = t.Name, Color = t.Color })
                                      .AsNoTracking()
                                      .ToListAsync();

                _cache.Set<List<SelectItem>>($"T{ProjectId}", typeItems);
            }

            return typeItems;
        }

        public async Task<List<SelectItem>> GetStatusSelectItems()
        {
            var statusItems = _cache.Get<List<SelectItem>>($"S{ProjectId}");

            if (statusItems == null)
            {
                statusItems = await _ctx.Status
                             .Where(s => (s.ProjectId == ProjectId) || (s.ProjectId == 0))
                             .Select(s => new SelectItem { Id = s.Id, Name = s.Name, Color = s.Color })
                             .AsNoTracking()
                             .ToListAsync();

                _cache.Set<List<SelectItem>>($"S{ProjectId}", statusItems);
            }

            return statusItems;
        }
    }
}