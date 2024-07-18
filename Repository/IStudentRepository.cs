using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform1._0.Repository
{
    public interface IStudentRepository
    {
         void Insert(RegisterViewModel user,string id);
         void Update(string id,Student student);
         void Delete(string id);
         List<Student> GetAll();
         Student GetById(string id);
        public List<Quiz> GetStudentQuizzesByStudentID(string studentID);
        int CalculateCorrectAnswersForQuiz(string studentId, int quizId);
       
    }
}
