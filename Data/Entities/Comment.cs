﻿using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Data.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        [StringLength(300)]
        public string Body { get; set; }
        public int IssueId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
