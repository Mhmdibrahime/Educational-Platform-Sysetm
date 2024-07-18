using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;

namespace EducationalPlatform1._0.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        AppDbContext Context;
        public QuestionRepository(AppDbContext context)
        {
            this.Context = context;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        //List<Question> GetQuestionsByQuizId(int id)
        //{
        //    return Context.Questions.Where(x=>x.QuizId==id).ToList();
        //}

       

        public void Insert(AddQuizViewModel addQuizViewModel)
        {
            Question question = new Question(); 
            question.question = addQuizViewModel.Question;
            question.OptionA = addQuizViewModel.OptionA;
            question.OptionB = addQuizViewModel.OptionB;
            question.OptionC = addQuizViewModel.OptionC;
            question.OptionD = addQuizViewModel.OptionD;
            question.CorrectAnswer = addQuizViewModel.CorrectAnswer;
            question.QuizId = addQuizViewModel.QuizId;
            Context.Questions.Add(question);
            Context.SaveChanges();
        }

        public void Update(string id, Question student)
        {
            throw new NotImplementedException();
        }

        List<Question> IQuestionRepository.GetQuestionsByQuizId(int id)
        {
            return Context.Questions.Where(x => x.QuizId == id).ToList();
        }
    }
}
