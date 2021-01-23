using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.ViewModel.IssueTable
{
    public class IssueTableFilter
    {
        [Display(Name = "Type")]
        public int TypeId { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        [Display(Name = "Per Page")]
        public int PerPage { get; set; } = 30;
    }
}
