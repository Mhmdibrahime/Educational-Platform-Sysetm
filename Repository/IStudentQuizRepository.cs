using EducationalPlatform1._0.Models.Entities;

namespace EducationalPlatform1._0.Repository
{
    public interface IStudentQuizRepository
    {
        void Insert(StudentQuiz student);
        void Update(string id, StudentQuiz student);
        void Delete(string id);
        List<StudentQuiz> GetAll();
        StudentQuiz GetById(string id);
    }
}
