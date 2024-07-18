using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;

namespace EducationalPlatform1._0.Repository
{
    public interface IFeedBackRepository
    {
        void Insert(FeedBackViewModel model);
        void Update(string id, FeedBack feedBack);
        void Delete(string id);
        List<FeedbackWithStudentViewModel> GetAllFeedBacks();
        FeedBack GetById(string id);
    }
}
