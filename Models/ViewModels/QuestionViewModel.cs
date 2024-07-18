namespace EducationalPlatform1._0.Models.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string SelectedOption { get; set; }
    }
}
