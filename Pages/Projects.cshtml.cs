using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Project1.Interfaces;
using Project1.Data;
using Project1.ViewModel.Projects;
using Project1.Extensions;
namespace Project1
{
    public class ProjectsModel : PageModel
    {
        private IProjectsViewModelService _projectsViewModelService;

        public ProjectsModel(IProjectsViewModelService projectsViewModelService)
        {
            _projectsViewModelService = projectsViewModelService;
        }

        
        public IReadOnlyList<ProjectViewModel> Projects { get; set; }
        
        public async Task OnGetAsync()
        {
            Projects = await _projectsViewModelService.GetProjects();

            TempData.Set("Projects", Projects);
        }


        public async Task<IActionResult> OnPostAsync(int ProjectId)
        {
            
            Projects = TempData.Get<IReadOnlyList<ProjectViewModel>>("Projects");

            if (Projects == null)
            {
                Projects = await _projectsViewModelService.GetProjects();
                TempData.Set("Projects", Projects);
                return Page();
            }

            foreach(var project in Projects)
            {
                if (ProjectId == project.Id)
                {
                    HttpContext.Session.SetInt32("projectId", ProjectId);
                    return RedirectToPage("/Dashboard");
                }
            }

            TempData.Keep();
            return Page();
        }
    }
}