using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;

namespace EducationalPlatform1._0.Repository
{
    public interface ITeacherRepository
    {

        void Insert(AddTeacherViewModel user, string id);
        
        void Update(string id, Teacher student);
             void Delete(string id);
             List<Teacher> GetAll();
             Teacher GetById(string id);
        
    }
}
