using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Interfaces;
using Project1.ViewModel.Projects;
using Project1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Project1.Services
{
    public class ProjectsViewModelService : IProjectsViewModelService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpCtxAccesor;

        public ProjectsViewModelService(ApplicationDbContext ctx,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpCtxAccesor)
        {
            _ctx = ctx;
            _userManager = userManager;
            _httpCtxAccesor = httpCtxAccesor;
        }

        public async Task<IReadOnlyList<ProjectViewModel>> GetProjects()
        {
            
            var userId = await GetUserId();

            var Projects = await _ctx.ProjectUsers
                                     .Include(pu => pu.Project)
                                     .Where(pu => pu.UserId == userId)
                                     .Select(pu => new ProjectViewModel { Id = pu.ProjectId, Name = pu.Project.Name })
                                     .ToListAsync();

            return Projects;
        }

        public async Task<int> GetUserId()
        {
            var user = _httpCtxAccesor.HttpContext.User;
            var userId =  (await _userManager.GetUserAsync(user)).Id;
            
            return userId ;
        }
    }
}
