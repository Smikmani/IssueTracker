using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1.Data
{
    public class Issue : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public int TypeId { get; set; }
        [Required]
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
