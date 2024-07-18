namespace EducationalPlatform1._0.Models.Entities
{
    public class StudentQuiz
    {
        public Student Student { get; set; }
        public string StudentId { get; set; }

        public Quiz Quiz { get; set; }
        public int QuizId { get; set;}
    }
}
