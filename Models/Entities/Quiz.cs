using Microsoft.Identity.Client;

namespace EducationalPlatform1._0.Models.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? NumberOfQuestions { get; set; }
        public List<StudentQuiz> studentQuizzes { get; set; } = new List<StudentQuiz>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public List<Question> questions { get; set; } = new List<Question>();
        public List<StudentAnswer> studentAnswers { get; set; }= new List<StudentAnswer>();
    }
}
