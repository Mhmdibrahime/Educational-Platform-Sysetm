namespace EducationalPlatform1._0.Models.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public int Percentage { get; set; } 
        public int WrongAnswers { get; set; }
        public int CorrectAnswers { get; set; }
        public string QuizTitle { get; set; }
        public Student? Student { get; set; }
        public string? StudentId { get; set; }
    }
}
