namespace EducationalPlatform1._0.Models.ViewModels
{
    public class FeedbackWithStudentViewModel
    {
        public string Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Image {  get; set; }
        public string Level { get; set; }
        public string Rating { get; set; }
        public string FeedBack { get; set; }

        public List<FeedbackWithStudentViewModel> Feedbacks { get; set; } = new List<FeedbackWithStudentViewModel>();
    }
}
