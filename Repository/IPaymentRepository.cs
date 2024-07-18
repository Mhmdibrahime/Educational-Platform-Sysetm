using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;

namespace EducationalPlatform1._0.Repository
{
    public interface IPaymentRepository
    {
        void Insert(PaymentViewModel payment,string StudentId);
        bool IsPaid(string id);
        void Update(string id, Payment student);
        void Delete(string id);
        List<Payment> GetAll();
        Payment GetById(string id);
    }
}
