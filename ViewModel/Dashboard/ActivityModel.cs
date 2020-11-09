
using System.ComponentModel.DataAnnotations;

namespace Project1.ViewModel.Dashboard
{
    public class ActivityModel
    {
        [Display(Name = "Open")]
        public int OpenIssueCount { get; set; }

        [Display(Name = "Closed")]
        public int ClosedIssueCount { get; set; }

        public float AverageIssuesAdded { get; set; }

        public float AverageIssuesClosed { get; set; }
    }
}
