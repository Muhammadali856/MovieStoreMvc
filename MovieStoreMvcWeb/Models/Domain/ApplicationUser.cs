using Microsoft.AspNetCore.Identity;

namespace MovieStoreMvcWeb.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
