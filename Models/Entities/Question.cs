namespace EducationalPlatform1._0.Models.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
        
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }

        public ICollection<StudentAnswer > StudentAnswers { get; set; } = new List<StudentAnswer>();
    }
}
