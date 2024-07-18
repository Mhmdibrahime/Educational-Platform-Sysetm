using EducationalPlatform1._0.Models.Data.Config;
using EducationalPlatform1._0.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;

namespace EducationalPlatform1._0.Models.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext() : base()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<StudentAnswer> StudentsAnswers { get; set; }
        public DbSet<StudentQuiz> studentQuizzes { get; set; }
        public DbSet<FeedBack> feedBacks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var constr = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(StudentConfig).Assembly);
        }
    }
}
