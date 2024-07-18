using EducationalPlatform1._0.Models;
using EducationalPlatform1._0.Models.ViewModels;
using EducationalPlatform1._0.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EducationalPlatform1._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeedBackRepository feedBackRepository;
        private readonly IPaymentRepository paymentRepository;

        public HomeController(ILogger<HomeController> logger,IFeedBackRepository feedBackRepository,IPaymentRepository paymentRepository)
        {
            _logger = logger;
            this.feedBackRepository = feedBackRepository;
            this.paymentRepository = paymentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                if (User.IsInRole("Teacher"))
                {
                    return RedirectToAction("OpenDashboard", "Teacher");
                }
                else if(User.IsInRole("Admin"))
                {
                    return RedirectToAction("OpenDashboard", "Admin");
                }
            }
            FeedBackViewModel model = new FeedBackViewModel();
            model.Feedbacks = feedBackRepository.GetAllFeedBacks();
            return View(model);
        }
        public IActionResult Months() 
        {
            if (User.Identity.IsAuthenticated == true)
            {
                if (User.IsInRole("Student"))
                {
                    string Id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                    if (paymentRepository.IsPaid(Id))
                    {
                        return View();
                    }
                    else return RedirectToAction("Pay", "User");
                }
                return View();
            }
            else return RedirectToAction("Login", "Account");
            
        }
        public IActionResult About()
        {

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
