using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project1.Data.Entities
{
    public class Issue : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public int TypeId { get; set; }
        public Types Type { get; set; }
        [Required]
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public int ProjectId { get; set; }
        [Display(Name="Due Date")]
        public DateTime? DueDate { get; set; }
        [JsonIgnore]
        public List<Comment> Comments { get; set; }
        [JsonIgnore]
        public List<Change> Changes { get; set; }
        [JsonIgnore]
        public List<FileDetails> Files { get; set; }
        //public int AssignedUserId { get; set; }
    }
}
