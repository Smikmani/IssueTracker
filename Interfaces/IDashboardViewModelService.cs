using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Data;
using Project1.Data.Entities;
using Project1.ViewModel.Dashboard;

namespace Project1.Interfaces
{
    public interface IDashboardViewModelService
    {
        Task<DashboardViewModel> GetDashboardViewModel();
        Task<ActivityModel> GetActivity(int Days = 15);
        Task<PieChartModel> GetTypePieChartData();
        Task<PieChartModel> GetStatusPieChartData();
        Task<LineChartModel> GetActivityLineChartData(int Days = 15);
    }
}
