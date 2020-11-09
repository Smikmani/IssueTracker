using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.ViewModel.Dashboard
{
    public class PieChartModel
    {
        public IReadOnlyList<string> Labels { get; set; }
        public IReadOnlyList<int> Values { get; set; }
        public IReadOnlyList<string> Colors { get; set; }
    }
}
