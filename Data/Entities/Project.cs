using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Project1.Data.Entities
{
    public class Project : BaseEntity
    {

        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        [Required]
        public int LeadId { get; set; }
        public List<ProjectUsers> ProjectUsers { get; set; }
    }
}
