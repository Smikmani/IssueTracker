using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Data.Entities;

namespace Project1.ViewModel.IssueTable
{
    public class IssueTableItemViewModel
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public Types  Type { get; set; }
        public Status Status { get; set; }
        public DateTime? DueDate { get; set; }

    }
}
