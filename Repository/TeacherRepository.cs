using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;

namespace EducationalPlatform1._0.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        AppDbContext Context;
        public TeacherRepository(AppDbContext context)
        {
            this.Context = context;
        }

        public void Delete(string id)
        {
            var teacher = Context.Teachers.FirstOrDefault(x => x.Id == id);


            Context.Teachers.Remove(teacher);
            Context.SaveChanges();
        }

        public List<Teacher> GetAll()
        {
            return Context.Teachers.ToList();
        }

        public Teacher GetById(string id)
        {
            throw new NotImplementedException();
        }

       

        public void Insert(AddTeacherViewModel user, string id)
        {
            Teacher teacher = new Teacher();
            teacher.Id = id;
            teacher.FirstName = user.FName;
            teacher.LastName = user.LName;
            teacher.Phone = user.PhoneNumber;
            teacher.Email = user.Email;
            teacher.Password = user.Password;
            
            teacher.Image = user.ImagePath;
            Context.Teachers.Add(teacher);
            Context.SaveChanges();
        }

        public void Update(string id, Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
