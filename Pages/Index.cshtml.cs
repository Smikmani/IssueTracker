using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using BugTracker.ViewModel;
using BugTracker.Interfaces;


namespace Project1
{
    public class IndexModel : PageModel
    {
        private readonly IDashboardViewModelService _dashboardViewModelService;
        public IndexModel(IDashboardViewModelService dashboardViewModelService)
        {
            _dashboardViewModelService = dashboardViewModelService;
        }
        public DashboardViewModel DashboardModel { get; set; } = new DashboardViewModel();
        public async Task  OnGet()
        {
           DashboardModel = await _dashboardViewModelService.GetDashboardData();
        }

    }
}