using EducationalPlatform1._0.Models.Entities;

namespace EducationalPlatform1._0.Models.ViewModels
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public List<Quiz> quizzes { get; set; } = new List<Quiz>();
        
        public List<Student> students { get; set; }
        public List<Teacher> teachers { get; set; }
    }
}
