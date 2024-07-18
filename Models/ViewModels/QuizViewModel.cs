using EducationalPlatform1._0.Models.Entities;

namespace EducationalPlatform1._0.Models.ViewModels
{
    public class QuizViewModel
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set; }
        public int? NumberOfQuestions { get; set; }
        public string StudentId { get; set; }
        public List<Question> Questions { get; set; }

        //public List<SelectedAnswer> SelectedAnswers { get; set; } = new List<SelectedAnswer>();
        //public List<string> CorrectAnswres { get; set; } = new List<string>();

    }
}
