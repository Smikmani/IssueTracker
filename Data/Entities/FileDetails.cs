using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Data.Entities
{
    public class FileDetails : BaseEntity
    {
        public string Uri { get; set; }
        public int IssueId { get; set; } 
        public int UserId { get; set; } 
    }
}
