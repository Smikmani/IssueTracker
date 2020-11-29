using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Data;
using Project1.ViewModel.Dashboard;
using Project1.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Project1.Services
{
    public class DashboardViewModelService : IDashboardViewModelService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IHttpContextAccessor _httpCtxAccessor;
        
        public DashboardViewModelService(ApplicationDbContext ctx,
                                         IHttpContextAccessor httpCtxAccessor)
        {
            _ctx = ctx;
            _httpCtxAccessor = httpCtxAccessor;
        }

        public int ProjectId { get; set; }

        public async Task<DashboardViewModel> GetDashboardViewModel()
        {
            var dashboardVM = new DashboardViewModel();
            ProjectId = (int)_httpCtxAccessor.HttpContext.Session.GetInt32("projectId");

            dashboardVM.Activity = await GetActivity();
            dashboardVM.TypePieChart = await GetTypePieChartData();
            dashboardVM.StatusPieChart = await GetStatusPieChartData();

            return dashboardVM;
        }

        public async Task<ActivityModel> GetActivity(int Days = 15)
        {

            var filterDate = DateTime.UtcNow.AddDays(-Days);

            ActivityModel activityModel = new ActivityModel();

            activityModel.OpenIssueCount = await GetOpenIssueCount();
            activityModel.ClosedIssueCount = await GetClosedIssueCount();
            activityModel.AverageIssuesAdded = await GetAverageIssuesAdded(filterDate)/Days;
            activityModel.AverageIssuesClosed = await GetAverageIssuesClosed(filterDate) / Days;

            return activityModel;

        }

        private async Task<int> GetOpenIssueCount()
        {
            return await _ctx.Issues
                             .Where(i =>(i.ProjectId == ProjectId) && (i.StatusId != 6) )
                             .CountAsync();
        }

        private async Task<int> GetClosedIssueCount()
        {
            return await _ctx.Issues
                             .Where(i => (i.ProjectId == ProjectId) && (i.StatusId == 6))
                             .CountAsync();
        }

        private async Task<float> GetAverageIssuesAdded(DateTime FilterDate)
        {

            var averageIssueAdded = await _ctx.Issues
                                              .Where(i => (i.ProjectId == ProjectId) && (i.CreationDate >= FilterDate))
                                              .CountAsync();
            return (float)averageIssueAdded;
        }
        
        private async Task<float> GetAverageIssuesClosed(DateTime FilterDate)
        {
            var averageIssueClosed = await _ctx.Issues
                                               .Where(i => (i.ProjectId == ProjectId) && (i.UpdateDate >= FilterDate) && (i.StatusId == 6))
                                               .CountAsync() ;

            return (float)averageIssueClosed ;
        }

        public async Task<PieChartModel> GetTypePieChartData()
        {
            PieChartModel pieChart = new PieChartModel();
            var labels = new List<string>();
            var values = new List<int>();
            var colors = new List<string>();

            var issueGroups = await _ctx.Issues
                                        .Include(i => i.Type)
                                        .Where(i => i.ProjectId == ProjectId)
                                        .GroupBy(i => i.TypeId)
                                        .Select(group => new { Key = group.Key, Count = group.Count() })
                                        .ToListAsync();

            var types = await _ctx.Types
                                    .Where(t => t.ProjectId == ProjectId || t.ProjectId == 0)
                                    .Select(t => new {t.Id, t.Name, t.Color })
                                    .ToListAsync();


           foreach (var group in issueGroups)
            {
                foreach (var type in types)
                {
                    if (group.Count==0) continue;
                    if(type.Id == group.Key)
                    {
                        labels.Add(type.Name);
                        values.Add(group.Count);
                        colors.Add(type.Color);
                    }
                    
                }
                
            }

            pieChart.Labels = labels;
            pieChart.Values = values;
            pieChart.Colors = colors;

            return pieChart;
        }

        public async Task<PieChartModel> GetStatusPieChartData()
        {
            PieChartModel pieChart = new PieChartModel();
            var labels = new List<string>();
            var values = new List<int>();
            var colors = new List<string>();

            var issueGroups = await _ctx.Issues
                                        .Include(i => i.Status)
                                        .Where(i => i.ProjectId == ProjectId)
                                        .GroupBy(i => i.StatusId)
                                        .Select(group => new { Key = group.Key, Count = group.Count() })
                                        .ToListAsync();
            var status = await _ctx.Status
                                    .Where(t => t.ProjectId == ProjectId || t.ProjectId == 0)
                                    .Select(s => new { s.Id, s.Name, s.Color })
                                    .ToListAsync();

            foreach (var group in issueGroups)
            {
                foreach (var st in status)
                {
                    if (group.Count == 0) continue;
                    if (st.Id == group.Key)
                    {
                        labels.Add(st.Name);
                        values.Add(group.Count);
                        colors.Add(st.Color);
                    }

                }

            }

            pieChart.Labels = labels;
            pieChart.Values = values;
            pieChart.Colors = colors;

            return pieChart;
        }

    }
}

