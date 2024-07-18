using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.Entities;

namespace EducationalPlatform1._0.Repository
{
    public class StudentQuizRepository : IStudentQuizRepository
    {
        AppDbContext Context;
        public StudentQuizRepository(AppDbContext context)
        {
            this.Context = context;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<StudentQuiz> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentQuiz GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(StudentQuiz student)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, StudentQuiz student)
        {
            throw new NotImplementedException();
        }
    }
}
