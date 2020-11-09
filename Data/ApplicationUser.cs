using Microsoft.AspNetCore.Identity;
using Project1.Data.Entities;
using System.Collections.Generic;

namespace Project1.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        public int TeamId { get; set; }
        public int JobRoleId { get; set; }
        public List<ProjectUsers> ProjectUsers { get; set; }
    }
}
