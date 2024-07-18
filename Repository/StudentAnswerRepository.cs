using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.Entities;

namespace EducationalPlatform1._0.Repository
{
    public class StudentAnswerRepository : IStudentAnswerRepository

    {
        private readonly AppDbContext context;

        public StudentAnswerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<StudentAnswer> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentAnswer GetById(string id)
        {
            throw new NotImplementedException();
        }

        //public void Insert(StudentAnswer student)
        //{
        //    context.Add(student);
        //    context.SaveChanges();
        //}

        public void Insert(List<StudentAnswer> student)
        {
            context.AddRange(student);
            context.SaveChanges();
        }

        public void Update(string id, StudentAnswer student)
        {
            throw new NotImplementedException();
        }
    }
}
