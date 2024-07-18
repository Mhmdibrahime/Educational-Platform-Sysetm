namespace EducationalPlatform1._0.Models.Entities
{
    public class StudentAnswer
    {
        public int Id { get; set; }
        public string StudentAnswers { get; set; }
        public Student Student { get; set; }
        public string StudentId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public Quiz? Quiz { get; set; }
        public int? QuizId { get; set;}
    }
}
