using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform1._0.Models.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string LastName { get; set; }
        public string Image { get; set; }

    }
}
