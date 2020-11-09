using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
