using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Data;
using Project1.ViewModel;

namespace Project1.Interfaces
{
    public interface IDashboardViewModelService
    {

        Task<DashboardViewModel> GetDashboardData();
        Chart GetChartData(IEnumerable<Issue> issues);

    }
}
