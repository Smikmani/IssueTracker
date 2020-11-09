using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project1.Data.Entities
{
    public class Team : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        public int ManagerId { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}
