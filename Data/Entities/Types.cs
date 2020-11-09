using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Data.Entities
{
    public class Types : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        public int ProjectId { get; set; }
        public List<Issue> Issues { get; set; }
    }
}
