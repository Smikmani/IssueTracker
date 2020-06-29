
using System.ComponentModel.DataAnnotations;

namespace Project1.Data
{
    public class IssueStatus : BaseEntity
    {
        [Required]
        public string Status { get; set; }
        [Required]
        public string Color {get; set; }
        public int ProjectId { get; set; }
    }
}
