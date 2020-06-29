using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Project1.ViewModel
{
    public class DashboardViewModel
    {
        public IEnumerable<DashboardIssueViewModel> Issues { get; set; }
        public Chart Chart { get; set; }

    }
}
