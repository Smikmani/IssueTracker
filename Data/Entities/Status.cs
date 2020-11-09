
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1.Data.Entities
{
    public class Status : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color {get; set; }
        public int ProjectId { get; set; }
        public List<Issue> Issues { get; set; }
    }
}
