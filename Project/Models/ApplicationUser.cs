using Microsoft.AspNetCore.Identity;

namespace Project.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
