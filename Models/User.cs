using Microsoft.AspNetCore.Identity;

namespace Swarojgaar.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string Location { get; set; }
    }
}
