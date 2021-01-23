using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.ViewModel.Shared;

namespace Project1.ViewModel.IssueTable
{
    public class IssueTableViewModel
    {
        public List<IssueTableItemViewModel> Issues { get; set; }
        public List<SelectItem> Types { get; set; }
        public List<SelectItem> Status { get; set; }
        public SelectItem SelectedType { get; set; }
        public SelectItem SelectedStatus { get; set; }

    }
}
