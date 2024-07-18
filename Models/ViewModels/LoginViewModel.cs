using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EducationalPlatform1._0.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(11,ErrorMessage ="Phone Number is invalid")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
