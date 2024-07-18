using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.ViewModels;
using EducationalPlatform1._0.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace EducationalPlatform1._0.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITeacherRepository teacherRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IFeedBackRepository feedBackRepository;
        private readonly AppDbContext context;

        public AdminController(UserManager<ApplicationUser> userManager,
            ITeacherRepository teacherRepository,
            IStudentRepository studentRepository,
            IFeedBackRepository feedBackRepository,
            AppDbContext context
            )
        {
            this.userManager = userManager;
            this.teacherRepository = teacherRepository;
            this.studentRepository = studentRepository;
            this.feedBackRepository = feedBackRepository;
            this.context = context;
        }

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
        public IActionResult Report(string id)
        {

            var student = studentRepository.GetById(id);

            ProfileViewModel model = new ProfileViewModel();
            model.Id = student.Id;
            model.Name = student.FirstName + " " + student.LastName;
            model.PhoneNumber = student.Phone;
            model.Email = student.Email;
            model.ImagePath = student.Image;
            model.quizzes = studentRepository.GetStudentQuizzesByStudentID(model.Id);
            model.Grades = context.Grades.Where(x => x.StudentId == model.Id).ToList();
            return View(model);

        }
        public async Task<IActionResult> DeleteStudent(string id)
        {

            ApplicationUser user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            studentRepository.Delete(id);
            return RedirectToAction("OpenDashBoard");
        }
        public IActionResult TeachersDetails()
        {
            TeacherViewModel model = new TeacherViewModel();
            model.Name = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Country).Value;
            model.Phone = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.MobilePhone).Value;
            model.Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            model.Image = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.StreetAddress).Value;
            model.teachers = teacherRepository.GetAll();
            return View(model);
        }

        public IActionResult SeeFeedBacks()
        {
            FeedBackViewModel model = new FeedBackViewModel();
            model.Feedbacks = feedBackRepository.GetAllFeedBacks();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTeacher(AddTeacherViewModel newuserVM )
        {
            if (ModelState.IsValid)
            {
                if (newuserVM.ImageFile != null && newuserVM.ImageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(newuserVM.ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserImages", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await newuserVM.ImageFile.CopyToAsync(stream);
                    }

                    
                    newuserVM.ImagePath = "/UserImages/" + fileName;
                }
                ApplicationUser usermodel = new ApplicationUser();
                usermodel.UserName = newuserVM.FName;
                usermodel.LastName = newuserVM.LName;
                usermodel.Email = newuserVM.Email;
                usermodel.PhoneNumber = newuserVM.PhoneNumber;
                usermodel.PasswordHash = newuserVM.Password;
                usermodel.Image = newuserVM.ImagePath;

                IdentityResult result = await userManager.CreateAsync(usermodel, newuserVM.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(usermodel, "Teacher");
                    teacherRepository.Insert(newuserVM, usermodel.Id);
                    return RedirectToAction("TeachersDetails");
                }
                else
                {
                    foreach (var erroritem in result.Errors)
                    {
                        ModelState.AddModelError("", erroritem.Description);
                    }
                }
            }
            return View(newuserVM);
        }
        public async Task<IActionResult> DeleteTeacher(string id)
        {
            teacherRepository.Delete(id);
            ApplicationUser user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction("TeachersDetails");
        }
    }
}
