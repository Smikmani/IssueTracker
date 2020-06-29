using System.ComponentModel.DataAnnotations;
using System;
namespace Project1.Data
{
    public class Comment : BaseEntity
    {
        [Required]
        [StringLength(300)]
        public string Body { get; set; }
        [Required]
        public int IssueId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
