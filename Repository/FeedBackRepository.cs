using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform1._0.Repository
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly AppDbContext context;

        public FeedBackRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        

        public List<FeedbackWithStudentViewModel> GetAllFeedBacks()
        {
            var feedbacksWithStudents = context.feedBacks
            .Join(context.Students,
                feedback => feedback.StudentId,
                student => student.Id,
                (feedback, student) => new
                {
                    Feedback = feedback,
                    Student = student
                })
            .Select(joinResult => new FeedbackWithStudentViewModel
            {
                Id=joinResult.Student.Id,
                FName = joinResult.Student.FirstName,
                LName = joinResult.Student.LastName,
                Email= joinResult.Student.Email,
                Image = joinResult.Student.Image,
                Level = joinResult.Student.Level,
                FeedBack = joinResult.Feedback.feedBack,
                Rating = joinResult.Feedback.Rate,
                //StudentId = joinResult.Feedback.StudentId,
                //Student = joinResult.Student.LastName // Attach student information to each feedback
            })
            .ToList();

            return feedbacksWithStudents;
        }

        public FeedBack GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(FeedBackViewModel model)
        {
           FeedBack feedBack = new FeedBack();
            feedBack.feedBack=model.Feedback;
            feedBack.Rate=model.Rating;
            feedBack.StudentId= model.StudentID;
            context.feedBacks.Add(feedBack);
            context.SaveChanges();
        }

        public void Update(string id, FeedBack feedBack)
        {
            throw new NotImplementedException();
        }
    }
}
