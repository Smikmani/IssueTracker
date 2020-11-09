using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Project1.Data;
using Project1.Interfaces;
using Project1.ViewModel.Create;
using Project1.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Project1.ViewModel.Shared;

namespace Project1.Services
{
    public class CreateViewModelService : ICreateViewModelService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IHttpContextAccessor _httpCtxAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authService;
        public CreateViewModelService(ApplicationDbContext ctx,
                                      IHttpContextAccessor httpCtxAccessor,
                                      UserManager<ApplicationUser> userManager,
                                      IAuthorizationService authService)
        {
            _ctx = ctx;
            _httpCtxAccessor = httpCtxAccessor;
            _userManager = userManager;
            _authService = authService;
        }

        public int ProjectId { get; set; }

        public async Task<CreateViewModel> GetCreateViewModel()
        {
            var createVM = new CreateViewModel();
            ProjectId = (int)_httpCtxAccessor.HttpContext.Session.GetInt32("projectId");

            createVM.Types = await GetTypesSelectItems();
            createVM.Status = await GetStatusSelectItems();
            createVM.Teams = await GetTeamsSelectItems();

            return createVM;
        }

        public async Task<List<SelectItem>> GetTypesSelectItems()
        {
            var typeItems = await _ctx.Types
                                        .Where(t => (t.ProjectId == ProjectId) || (t.ProjectId == 0))
                                        .Select(t => new SelectItem { Id = t.Id, Name = t.Name, Color = t.Color })
                                        .ToListAsync();

            return typeItems;
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

        public async Task CreateIssue(Issue issue)
        {
            
            var user = _httpCtxAccessor.HttpContext.User;

            if (!(await _authService.AuthorizeAsync(user, "CanAssignTeam")).Succeeded)
            {
                issue.TeamId = 0;
            }

            var userId = (await _userManager.GetUserAsync(user)).Id;

            issue.UserId = userId;
            issue.ProjectId = (int)_httpCtxAccessor.HttpContext.Session.GetInt32("projectId");
            
            await _ctx.Issues.AddAsync(issue);
            await _ctx.SaveChangesAsync();
        }
    }
}
