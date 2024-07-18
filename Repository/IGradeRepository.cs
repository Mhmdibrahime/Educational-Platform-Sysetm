using Azure.Core.GeoJson;
using EducationalPlatform1._0.Models.Entities;

namespace EducationalPlatform1._0.Repository
{
    public interface IGradeRepository
    {
        void Insert(Grade student);
        void Update(string id, Grade student);
        void Delete(string id);
        List<Grade> GetAll();
        Grade GetById(string id);
    }
}
