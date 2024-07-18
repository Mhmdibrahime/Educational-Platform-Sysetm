using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.ViewModels;
using EducationalPlatform1._0.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EducationalPlatform1._0.Controllers
{
    [Authorize (Roles = "Teacher") ]
    public class TeacherController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IQuizRepository quizRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IFeedBackRepository feedBackRepository;
        private readonly AppDbContext context;

        public TeacherController(
            UserManager<ApplicationUser> userManager,
            IQuizRepository quizRepository,
            IQuestionRepository questionRepository,
            IStudentRepository studentRepository,
            IFeedBackRepository feedBackRepository,
            AppDbContext context
            )
        {
            this.userManager = userManager;
            this.quizRepository = quizRepository;
            this.questionRepository = questionRepository;
            this.studentRepository = studentRepository;
            this.feedBackRepository = feedBackRepository;
            this.context = context;
        }

        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Teacher1()
        {
            return View();
        }

        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Teacher2()
        {
            return View();
        }

        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Teacher3()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OpenDashboard()
        {
            TeacherViewModel model = new TeacherViewModel();
            model.Name = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Country).Value;
            model.Phone = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.MobilePhone).Value;
            model.Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            model.Image = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.StreetAddress).Value;
            model.students = studentRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddQuiz()
        {
            AddQuizViewModel addQuizViewModel = new AddQuizViewModel();
            return View(addQuizViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddQuiz(AddQuizViewModel addQuizVM)
            {
            if (addQuizVM != null)
            {
                quizRepository.Insert(addQuizVM);
                int quizId = addQuizVM.QuizId;
                return RedirectToAction("AddQuestionsToQuiz", new {quizId});
            }
            return View(addQuizVM);
        }

        [HttpGet]
        public IActionResult AddQuestionsToQuiz(int quizId)
        {
            AddQuizViewModel addQuizViewModel = new AddQuizViewModel { QuizId = quizId};
            return View(addQuizViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddQuestion(AddQuizViewModel model)
        {
            if(model != null)
            { 
                string selectedOption = Request.Form["CorrectAnswer"];

            // Set the CorrectAnswer property based on the selected option
            switch (selectedOption)
            {
                case "OptionA":
                    model.CorrectAnswer = model.OptionA;
                    break;
                case "OptionB":
                    model.CorrectAnswer = model.OptionB;
                    break;
                case "OptionC":
                    model.CorrectAnswer = model.OptionC;
                    break;
                case "OptionD":
                    model.CorrectAnswer = model.OptionD;
                    break;
                default:
                    // Handle default case if necessary
                    break;
            }
            
                questionRepository.Insert(model);
                return RedirectToAction("AddQuestionsToQuiz", new {quizId = model.QuizId});
            }
            return View(model);
        }

       
        public IActionResult Report(string id)
        {

            var student =studentRepository.GetById(id);
            
                ProfileViewModel model = new ProfileViewModel();
                model.Id= student.Id;
                model.Name=student.FirstName+" "+student.LastName;
                model.PhoneNumber = student.Phone;
                model.Email=student.Email;
                model.ImagePath = student.Image;
                model.quizzes = studentRepository.GetStudentQuizzesByStudentID(model.Id);
                model.Grades = context.Grades.Where(x => x.StudentId == model.Id).ToList();
            return View(model);
            
        }

        public IActionResult SeeFeedBacks()
        {
            FeedBackViewModel model = new FeedBackViewModel();
            model.Feedbacks = feedBackRepository.GetAllFeedBacks();
            return View(model);
        }

        
        public async Task<IActionResult> DeleteStudent(string id)
        {
            
            ApplicationUser user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            studentRepository.Delete(id);
            return RedirectToAction("OpenDashBoard");
        }
    }
}
