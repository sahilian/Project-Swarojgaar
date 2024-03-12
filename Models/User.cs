using Microsoft.AspNetCore.Identity;

namespace Swarojgaar.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public string DocFile { get; set; }
    }
}
