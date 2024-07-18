using EducationalPlatform1._0.Models.Entities;

namespace EducationalPlatform1._0.Repository
{
    public interface IStudentAnswerRepository
    {
        void Insert(List<StudentAnswer> student);
        void Update(string id, StudentAnswer student);
        void Delete(string id);
        List<StudentAnswer> GetAll();
        StudentAnswer GetById(string id);
    }
}
