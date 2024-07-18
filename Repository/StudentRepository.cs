using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform1._0.Repository
{
    public class StudentRepository : IStudentRepository
    {
        AppDbContext Context;
        public StudentRepository(AppDbContext context)
        {
            this.Context = context;
        }

        public int CalculateCorrectAnswersForQuiz(string studentId, int quizId)
        {
            
            var studentAnswersForQuiz = Context.StudentsAnswers
                .Where(sa => sa.StudentId == studentId && sa.QuizId == quizId)
                .ToList();

            int correctAnswersCount = 0;

            foreach (var studentAnswer in studentAnswersForQuiz)
            {
                var question = Context.Questions.FirstOrDefault(q => q.Id == studentAnswer.QuestionId);

                if (question != null && studentAnswer.StudentAnswers == question.CorrectAnswer)
                {
                    correctAnswersCount++;
                }
            }

            return correctAnswersCount;
        }

        public void Delete(string id)
        {
            var student = Context.Students.FirstOrDefault(x => x.Id == id);
            
            
                Context.Students.Remove(student);
                Context.SaveChanges();
            
        }

        public List<Student> GetAll()
        {
            return Context.Students.ToList();
        }

        public Student GetById(string id)
        {
            return Context.Students.FirstOrDefault(x => x.Id == id);
        }
        public List<Quiz> GetStudentQuizzesByStudentID(string studentID) 
        {
            
            var quizzes = Context.Quizzes
                        .Where(q => q.studentQuizzes.Any(sq => sq.StudentId == studentID))
                        .ToList();

            return quizzes;
        }
        public void Insert(RegisterViewModel user,string id)
        {
            Student student = new Student();
            student.Id = id;
            student.FirstName = user.FName;
            student.LastName=user.LName;
            student.Phone = user.PhoneNumber;
            student.Email = user.Email;
            student.Password = user.Password;
            student.Level= user.Level;
            student.Image = user.ImagePath;
            Context.Students.Add(student);
            Context.SaveChanges();
        }

        public void Update(string id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
