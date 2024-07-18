using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;

namespace EducationalPlatform1._0.Repository
{
    public interface IQuizRepository
    {
        void Insert(AddQuizViewModel addQuizViewModel);
        void Update(string id, Quiz student);
        void Delete(string id);
        List<Quiz> GetAll();
        Quiz GetById(string id);
        Quiz GetQuizById(int id);
    }
}
