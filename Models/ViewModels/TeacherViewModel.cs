using EducationalPlatform1._0.Models.Entities;

namespace EducationalPlatform1._0.Models.ViewModels
{
    public class TeacherViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public List<Student> students { get; set; }
        public List<Teacher> teachers { get; set; }
    }
}
