using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Data;
using Project1.Data.Entities;

namespace Project1.Pages.Shared.Components.DoughnutChart
{
    public class DoughnutChart : ViewComponent
    {
        private ApplicationDbContext _ctx { get; set; }
        public DoughnutChart(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        DoughnutChartModel chart = new DoughnutChartModel();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var labels = new List<int>();
            var values = new List<int>();

            
            var a = _ctx.Issues.ToList()
                               .GroupBy(i => (int)i.GetType()
                               .GetProperty("TypeId")
                               .GetValue(i, null))
                               .Select(group => { labels.Add(group.Key); values.Add(group.Count()); return group; })
                               .ToArray();

            chart.Labels = labels;
            chart.Values = values;

            return View(chart);
        }
    }

    public class DoughnutChartModel
    {
        public IEnumerable<int> Labels { get; set; }
        public IEnumerable<int> Values { get; set; }

    }
}
