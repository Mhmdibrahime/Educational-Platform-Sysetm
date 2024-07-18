using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.Entities;

namespace EducationalPlatform1._0.Repository
{
    public class GradeRepository : IGradeRepository
    {
        AppDbContext Context;
        public GradeRepository(AppDbContext context)
        {
            this.Context = context;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Grade> GetAll()
        {
            throw new NotImplementedException();
        }

        public Grade GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Grade student)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Grade student)
        {
            throw new NotImplementedException();
        }
    }
}
