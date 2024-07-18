using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Models.ViewModels;
using EducationalPlatform1._0.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EducationalPlatform1._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStudentRepository studentRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(IStudentRepository studentRepo, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager) 
        {
            this.studentRepo = studentRepo;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newuserVM)
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

                    // Save file path in ViewModel
                    newuserVM.ImagePath = "/UserImages/" + fileName;
                }
                ApplicationUser usermodel = new ApplicationUser();
                usermodel.UserName = newuserVM.FName;
                usermodel.LastName = newuserVM.LName;
                usermodel.Email = newuserVM.Email;
                usermodel.PhoneNumber = newuserVM.PhoneNumber;
                usermodel.PasswordHash = newuserVM.Password;
                usermodel.Image = newuserVM.ImagePath;
                
                IdentityResult result = await userManager.CreateAsync(usermodel,newuserVM.Password);
                
                if (result.Succeeded)
                {
                    
                    await userManager.AddToRoleAsync(usermodel,"Student");
                    studentRepo.Insert(newuserVM, usermodel.Id);
                    signInManager.SignInAsync(usermodel,false);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach(var erroritem in result.Errors)
                    {
                        ModelState.AddModelError("", erroritem.Description);
                    }
                }
            }
            return View(newuserVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(userVM.Email);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, userVM.Password);
                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Country, user.UserName+ " " +user.LastName));
                        claims.Add(new Claim (ClaimTypes.Email, user.Email));   
                        claims.Add(new Claim (ClaimTypes.StreetAddress, user.Image));   
                        claims.Add(new Claim (ClaimTypes.MobilePhone, user.PhoneNumber));   
                          
                        await signInManager.SignInWithClaimsAsync(user, userVM.RememberMe ,claims);
                       //if(User.IsInRole("Student"))
                        return RedirectToAction("Welcome", "Home");
                        //else if(User.IsInRole("Techer"))
                        //    return RedirectToAction("OpenDashBoard", "Teacher");
                    }
                }
                ModelState.AddModelError("", "Wrong Email or Password or Phone Number");
            }
            return View(userVM);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Welcome", "Home");
        }
    }
}
