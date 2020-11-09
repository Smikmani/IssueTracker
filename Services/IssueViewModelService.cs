using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Data.Entities;
using Project1.Interfaces;
using Project1.ViewModel.Issues;
using Project1.ViewModel.Shared;

namespace Project1.Services
{

    public class IssueViewModelService :IIssueViewModelService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IHttpContextAccessor _httpCtxAccessor;


        public IssueViewModelService(ApplicationDbContext  ctx, 
                                     IHttpContextAccessor httpCtxAccessor)
        {
            _ctx = ctx;
            _httpCtxAccessor = httpCtxAccessor;

        }

        public int ProjectId { get; set; }

        public async Task<IssueViewModel> GetIssueViewModel(int id)
        {
            var issueVM = new IssueViewModel();
            ProjectId = (int)_httpCtxAccessor.HttpContext.Session.GetInt32("projectId");

            issueVM.Issue = await GetIssue(id);
            issueVM.Issue.Comments.Sort((a,b) => a.CreationDate.CompareTo(b.CreationDate));
            issueVM.Types = await GetTypesSelectItems();
            
            issueVM.Status = await GetStatusSelectItems();
            issueVM.Teams = await GetTeamsSelectItems();
            return issueVM;
        }

        public async Task<Issue> GetIssue(int id)
        {
            return await _ctx.Issues.Where(i =>  i.Id == id)
                                    .Include(i =>   i.Type)
                                    .Include(i => i.Status)
                                    .Include(i => i.Comments)
                                    .Include(i => i.Changes)
                                    .FirstAsync();
        }

        public async Task<List<SelectItem>> GetStatusSelectItems()
        {
            var statusItems = await _ctx.Status
                             .Where(s => (s.ProjectId == ProjectId) || (s.ProjectId == 0))
                             .Select(s => new SelectItem { Id = s.Id, Name = s.Name, Color = s.Color })
                             .ToListAsync();

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
            var typeItems = await _ctx.Types
                                       .Where(t => (t.ProjectId == ProjectId) || (t.ProjectId == 0))
                                       .Select(t => new SelectItem { Id = t.Id, Name = t.Name, Color = t.Color })
                                       .ToListAsync();

            return typeItems;
        }

        //public 
    }
}
