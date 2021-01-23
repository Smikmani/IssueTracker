using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project1.ViewModel.Dashboard;
using Project1.Interfaces;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Project1
{
    public class DashboardModel : PageModel
    {
        private IDashboardViewModelService _dashVMService;
        public DashboardModel(IDashboardViewModelService dashVMService)
        {
            _dashVMService = dashVMService;
        }

        [BindProperty]
        public DashboardViewModel DashboardVM { get; set; } = new DashboardViewModel();

        public async Task OnGetAsync()
        {
            DashboardVM = await _dashVMService.GetDashboardViewModel();
        }

    }
}