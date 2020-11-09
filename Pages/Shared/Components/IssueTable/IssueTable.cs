using System.Linq;
using System.Threading.Tasks;
using Project1.Data;
using System.Collections.Generic;
using Project1.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Project1.Pages.Shared.Components.IssueTable
{
    public class IssueTable : ViewComponent
    {
        private ApplicationDbContext _ctx;
        private IHttpContextAccessor _httpCtxAccessor;
        private int ProjectId { get; set; }
        public IssueTable(ApplicationDbContext ctx,
                          IHttpContextAccessor httpCtxAccessor)
        { 
            _ctx = ctx;
            _httpCtxAccessor = httpCtxAccessor;
        }

        public IReadOnlyList<IssueTableViewModel> Issues { get; set; }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ProjectId = (int)_httpCtxAccessor.HttpContext.Session.GetInt32("projectId");
            await GetIssues();
            return View(Issues);
        }

        public async Task GetIssues()
        {
            Issues = await _ctx.Issues.Where(i => i.ProjectId == ProjectId)
                                      .Include(i => i.Type)
                                      .Include(i => i.Status)
                                      .Select(i => new IssueTableViewModel()
                                       {
                                           Id = i.Id,
                                           Name = i.Name,
                                           Type = i.Type,
                                           Status = i.Status,
                                           Created = i.CreationDate.ToString("MM/dd/yyyy")
                                       })
                                      .OrderByDescending(i => i.Id)
                                      .ToListAsync();
        }
    }

    public class IssueTableViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Types Type { get; set; }
        public Status Status { get; set; }
        public string Created { get; set; }
    }
}
