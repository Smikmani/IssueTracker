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
        //private Use
        public DashboardModel(IDashboardViewModelService dashVMService)
        {
            _dashVMService = dashVMService;
        }

        [BindProperty]
        public DashboardViewModel dashboardVM { get; set; } = new DashboardViewModel();
        public string typePieLabels { get; set; }
        public string typePieValues { get; set; }
        public string typePieColors { get; set; }
        public string statusPieLabels { get; set; }
        public string statusPieValues { get; set; }
        public string statusPieColors { get; set; }

        public async Task OnGetAsync()
        {
            dashboardVM = await _dashVMService.GetDashboardViewModel();
            ChartDataToJson();
        }

        public void ChartDataToJson()
        {
            typePieValues = JsonSerializer.Serialize(dashboardVM.TypePieChart.Values);
            typePieLabels = JsonSerializer.Serialize(dashboardVM.TypePieChart.Labels);
            typePieColors = JsonSerializer.Serialize(dashboardVM.TypePieChart.Colors);
            statusPieValues = JsonSerializer.Serialize(dashboardVM.StatusPieChart.Values);
            statusPieLabels = JsonSerializer.Serialize(dashboardVM.StatusPieChart.Labels);
            statusPieColors = JsonSerializer.Serialize(dashboardVM.StatusPieChart.Colors);
        }
    }
}