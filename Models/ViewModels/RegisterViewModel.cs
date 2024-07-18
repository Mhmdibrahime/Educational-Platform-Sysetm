using System.ComponentModel.DataAnnotations;

namespace EducationalPlatform1._0.Models.ViewModels
{
    public class RegisterViewModel
    {


        public string FName { get; set; }
        public string LName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [StringLength(11,ErrorMessage ="Phone Number is invalid")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password doesn't match")]
        public string ConfirmPassword { get; set; }

        public string Level { get; set; }
        
        public IFormFile? ImageFile {  get; set; }
        public string? ImagePath {  get; set; }
    }
}
