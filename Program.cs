using EducationalPlatform1._0.Models.Data;
using EducationalPlatform1._0.Repository;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform1._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetSection("constr").Value);
            });

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<IQuizRepository, QuizRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IGradeRepository,GradeRepository >();
            builder.Services.AddScoped<IStudentQuizRepository,StudentQuizRepository >();
            builder.Services.AddScoped<IStudentAnswerRepository,StudentAnswerRepository >();
            builder.Services.AddScoped<IFeedBackRepository,FeedBackRepository >();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            }).AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            // if (User.Identity.IsAuthenticated == false)
//            app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action}/{id?}",
//    constraints: new { action = new AuthConstraint() }
//);

            app.MapControllerRoute(
                
                name: "default",
                pattern: "{controller=Home}/{action=welcome}/{id?}");

            app.Run();
        }
    }
}
