using NuGet.Protocol.Core.Types;

namespace EducationalPlatform1._0.Models.ViewModels
{
    public class FeedBackViewModel
    {
        public string Feedback { get; set; }
        public string Rating { get; set; }
        public string StudentID { get; set; }
        public List<FeedbackWithStudentViewModel> Feedbacks { get; set; } = new List<FeedbackWithStudentViewModel>();

    }
}
