using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Project1.Data;
using Project1.Data.Entities;
using Project1.Interfaces;
using Project1.ViewModel.Issues;
using Project1.ViewModel.Shared;
using Project1.Extensions;
namespace Project1.Services
{

    public class IssueViewModelService :IIssueViewModelService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IHttpContextAccessor _httpCtxAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDistributedCache _cache;
        private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromSeconds(30);

        public IssueViewModelService(ApplicationDbContext  ctx, 
                                     IHttpContextAccessor httpCtxAccessor,
                                     UserManager<ApplicationUser> userManager,
                                     IDistributedCache cache)
        {
            _ctx = ctx;
            _httpCtxAccessor = httpCtxAccessor;
            _userManager = userManager;
            _cache = cache;
        }

        public int ProjectId { get; set; }

        public async Task<IssueViewModel> GetIssueViewModel(int issueId)
        {
            var issueVM = new IssueViewModel();
            ProjectId = (int)_httpCtxAccessor.HttpContext.Session.GetInt32("projectId");

            issueVM.Issue = await GetIssue(issueId);
            issueVM.Types = await GetTypesSelectItems();
            issueVM.Status = await GetStatusSelectItems();
            issueVM.Teams = await GetTeamsSelectItems();
            issueVM.UserId = await GetUserId();

            return issueVM;
        }

        public async Task<Issue> GetIssue(int issueId)
        {
            
            return await _ctx.Issues.Where(i =>  i.Id == issueId && i.ProjectId == ProjectId)
                                    .Include(i => i.Type)
                                    .Include(i => i.Status)
                                    .Include(i => i.Comments)
                                    .Include(i => i.Changes)
                                    .Include(i => i.Files)
                                    .FirstOrDefaultAsync();
        }

        public async Task<List<SelectItem>> GetStatusSelectItems()
        {
            var statusItems = _cache.Get<List<SelectItem>>($"s{ProjectId}");
            
            if (statusItems == null)
            {
                statusItems = await _ctx.Status
                             .Where(s => (s.ProjectId == ProjectId) || (s.ProjectId == 0))
                             .Select(s => new SelectItem { Id = s.Id, Name = s.Name, Color = s.Color })
                             .ToListAsync();

                _cache.Set<List<SelectItem>>($"s{ProjectId}", statusItems);
            }

            return statusItems;
        }

        public async Task<List<SelectItem>> GetTeamsSelectItems()
        {
            
            var teamsItems = await _ctx.Teams
                                       .Where(t => (t.ProjectId == ProjectId))
                                       .Select(t => new SelectItem { Id = t.Id, Name = t.Name })
                                       .ToListAsync();

            return teamsItems;
        }

        public async Task<List<SelectItem>> GetTypesSelectItems()
        {
            var typeItems = _cache.Get <List<SelectItem>>($"t{ProjectId}");
            if(typeItems == null)
            {
                typeItems = await _ctx.Types
                                      .Where(t => (t.ProjectId == ProjectId) || (t.ProjectId == 0))
                                      .Select(t => new SelectItem { Id = t.Id, Name = t.Name, Color = t.Color })
                                      .ToListAsync();

                _cache.Set<List<SelectItem>>($"t{ProjectId}", typeItems);

            }


            return typeItems;
        }

        public async Task<int> GetUserId()
        {
            var user = _httpCtxAccessor.HttpContext.User;

            var userId = (await _userManager.GetUserAsync(user)).Id;

            return userId;
        }
        //public 
    }
}
