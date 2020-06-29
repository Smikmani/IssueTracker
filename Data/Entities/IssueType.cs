using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Data
{
    public class IssueType : BaseEntity
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string Color { get; set; }
        public int ProjectId { get; set; }
    }
}
