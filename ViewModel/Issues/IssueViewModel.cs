using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Data.Entities;
using Project1.ViewModel.Shared;

namespace Project1.ViewModel.Issues
{
    public class IssueViewModel
    {
        public int UserId { get; set; }
        public Issue Issue { get; set; }
        public List<SelectItem> Types { get; set; }
        public List<SelectItem> Status { get; set; }
        public List<SelectItem> Teams { get; set; }
    }
}
