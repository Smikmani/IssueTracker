using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Data;
using Project1.ViewModel;
using Project1.Interfaces;
 

namespace Project1.Services
{
    public class DashboardViewModelService : IDashboardViewModelService
    {
        private IIssueRepository rep;
        private DashboardViewModel dashboardViewModel = new DashboardViewModel();
        public DashboardViewModelService(IIssueRepository repository)
        {
            rep = repository;
        }
        
        public async Task<DashboardViewModel> GetDashboardData()
        {

            await GetIssues();
            
            return dashboardViewModel;
        }
        public async Task GetIssues()
        {
            
            var issues = await rep.ListAllIssuesAsync();

            dashboardViewModel.Chart = GetChartData(issues);

            var issuesViewModel = issues.Select(i => new DashboardIssueViewModel()
            {
                Id = i.Id,
                Name = i.Name,
                StatusId = i.StatusId,
                TypeId = i.TypeId
            });
            
            dashboardViewModel.Issues = issuesViewModel;
        }

        

        public Chart GetChartData(IEnumerable<Issue> issues)
        {
            var labels = new List<int>();
            var values = new List<int>();
            
            var chart = new Chart();
            
            issues.GroupBy(i => i.TypeId).Select(group => { labels.Add(group.Key); values.Add(group.Count()); return group; }).ToArray();
            
            chart.Labels = labels;
            chart.Values = values;

            return chart;
        }

    }
}

