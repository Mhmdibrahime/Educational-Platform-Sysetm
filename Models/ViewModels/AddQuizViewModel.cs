namespace EducationalPlatform1._0.Models.ViewModels
{
    public class AddQuizViewModel
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set;}
        public int NumberOfQuestions { get; set;}
        public string Question {  get; set;}
        public string OptionA { get; set;}
        public string OptionB { get; set;}
        public string OptionC { get; set;}
        public string OptionD { get; set;}
        public string CorrectAnswer { get; set;}
    }
}
