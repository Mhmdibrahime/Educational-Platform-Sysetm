using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;

namespace EducationalPlatform1._0.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        AppDbContext Context;
        public PaymentRepository(AppDbContext context)
        {
            this.Context = context;
        }

        

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Payment GetById(string id)
        {
            throw new NotImplementedException();
        }

       

       

        public void Insert(PaymentViewModel payment, string StudentId)
        {
            Payment newpay = new Payment();
            newpay.CardNumber = payment.CardNumber;
            newpay.ExpireDate = payment.ExpireDate;
            newpay.CVV = payment.CVV;
            newpay.studentId = StudentId;
            Context.Payments.Add(newpay);
            Context.SaveChanges();
        }

        public bool IsPaid(string id)
        {
            var check = Context.Payments.FirstOrDefault(x => x.studentId == id);
            if (check != null)
            {
                return true;
            }
            else return false;
        }

        public void Update(string id, Payment student)
        {
            throw new NotImplementedException();
        }
    }
}
