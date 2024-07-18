using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;

namespace EducationalPlatform1._0.Repository
{
    public class QuizRepository : IQuizRepository
    {
        AppDbContext Context;
        public QuizRepository(AppDbContext context)
        {
            this.Context = context;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Quiz> GetAll()
        {
            throw new NotImplementedException();
        }

        public Quiz GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Quiz GetQuizById(int id)
        {
            return Context.Quizzes.FirstOrDefault(x=>x.Id==id);
            //return 
        }

       

        public void Insert(AddQuizViewModel addQuizViewModel)
        {
            Quiz quiz = new Quiz();
            quiz.Id = addQuizViewModel.QuizId;
            quiz.Title=addQuizViewModel.QuizTitle;
            quiz.NumberOfQuestions=addQuizViewModel.NumberOfQuestions;
            Context.Quizzes.Add(quiz);
            Context.SaveChanges();
        }

        public void Update(string id, Quiz student)
        {
            throw new NotImplementedException();
        }
    }
}
