
using Microsoft.AspNetCore.Identity;

namespace Project1.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        public int TeamId { get; set; }

    }
}
