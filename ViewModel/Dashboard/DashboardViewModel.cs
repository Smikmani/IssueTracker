using System.Collections.Generic;
using Project1.Data.Entities;

namespace Project1.ViewModel.Dashboard
{
    public class DashboardViewModel
    {
        public PieChartModel TypePieChart { get; set; }
        public PieChartModel StatusPieChart { get; set; }
        public ActivityModel Activity { get; set; }
    }   
}
