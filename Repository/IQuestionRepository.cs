using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;

namespace EducationalPlatform1._0.Repository
{
    public interface IQuestionRepository
    {
        void Insert(AddQuizViewModel addQuizViewModel);
        void Update(string id, Question student);
        void Delete(string id);
        List<Question> GetAll();
        List<Question> GetQuestionsByQuizId(int id);

    }
}
