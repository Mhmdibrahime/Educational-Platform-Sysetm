using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.Entities;
using EducationalPlatform1._0.Models.ViewModels;
using EducationalPlatform1._0.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EducationalPlatform1._0.Controllers
{
    [Authorize (Roles ="Student")]
    public class UserController : Controller
    {
        AppDbContext context = new AppDbContext();

        private readonly IStudentRepository studentRepository;
        private readonly IQuizRepository quizRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IStudentAnswerRepository studentAnswerRepository;
        private readonly IFeedBackRepository feedBackRepository;
        private readonly IPaymentRepository paymentRepository;
        private readonly ITeacherRepository teacherRepository;

        public UserController(IStudentRepository studentRepository,
            IQuizRepository quizRepository,
            IQuestionRepository questionRepository,
            IStudentAnswerRepository studentAnswerRepository,
            IFeedBackRepository feedBackRepository,
            IPaymentRepository paymentRepository,
            ITeacherRepository teacherRepository
            
            )
        {
            this.studentRepository = studentRepository;
            this.quizRepository = quizRepository;
            this.questionRepository = questionRepository;
            this.studentAnswerRepository = studentAnswerRepository;
            this.feedBackRepository = feedBackRepository;
            this.paymentRepository = paymentRepository;
            this.teacherRepository = teacherRepository;
        }
        [HttpGet]
        public IActionResult Profile()
        {
            ProfileViewModel model = new ProfileViewModel();
            model.Id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            model.Name = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Country).Value;
            model.PhoneNumber = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.MobilePhone).Value;
            model.Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            model.ImagePath = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.StreetAddress).Value;
            model.quizzes = studentRepository.GetStudentQuizzesByStudentID(model.Id);
            
            model.Grades=context.Grades.Where(x=>x.StudentId==model.Id).ToList();
            if (User.IsInRole("Student"))
            {
                return View("Profile", model);
            }
            else if (User.IsInRole("Teacher"))
            {
                model.students = studentRepository.GetAll();
                return View("TeacherProfile", model);
            }
            else
            {
                model.students = studentRepository.GetAll();
                model.teachers = teacherRepository.GetAll();
                return View("AdminProfile", model);
            }

        }

        
        [HttpGet]
        public IActionResult Quiz(int id)
        {


            QuizViewModel quizVM = new QuizViewModel();
            Quiz quiz = quizRepository.GetQuizById(id);
            quizVM.QuizTitle=quiz.Title;
            quizVM.Questions=context.Questions.Where(x=>x.QuizId==id).ToList();
            TempData["QuizId"] = id;
            TempData["QuizTitle"] = quizVM.QuizTitle;

            return View(quizVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitQuiz( List<string> answers, List<int> questionIds)
        {
            string studentId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            for (int i = 0; i <answers.Count ; i++)
            {
                StudentAnswer studentAnswer = new StudentAnswer
                {
                    QuestionId = questionIds[i],
                    StudentAnswers = answers[i],
                    StudentId = studentId ,
                    QuizId = (int)TempData["QuizId"]

                };
              

                
                context.StudentsAnswers.Add(studentAnswer);
            }
            context.SaveChanges();
            //StudentQuiz studentQuiz = new StudentQuiz
            //{
            //    QuizId = (int)TempData["QuizId"],
            //    StudentId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value
            //};
            //context.studentQuizzes.Add(studentQuiz);
            //context.SaveChanges();


            int CorrectAnswers = studentRepository.CalculateCorrectAnswersForQuiz(studentId, (int)TempData["QuizId"]);
                int wronganswers = 20 - CorrectAnswers;
            int percentage = (int) ( ( (decimal)CorrectAnswers / 20m) * 100);
            Grade grade = new Grade()
            {
                StudentId=studentId,
                CorrectAnswers = CorrectAnswers,
                WrongAnswers = wronganswers,
                Percentage = percentage,
                QuizTitle = (string)TempData["QuizTitle"]
                };
                context.Grades.Add(grade);
                context.SaveChanges();

            return RedirectToAction("Profile","User");
        }

        [HttpGet]
        public IActionResult AddFeedBack()
        {
            FeedBackViewModel model = new FeedBackViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFeedBack(FeedBackViewModel model)
        {
            if(model!=null)
            {
                var studentId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                model.StudentID= studentId;
                feedBackRepository.Insert(model);
                return RedirectToAction("Months", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Pay()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pay(PaymentViewModel model)
        {
            string StudentId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
                
                paymentRepository.Insert(model,StudentId);
                return RedirectToAction("Months", "Home");
            
        }

    }
}
