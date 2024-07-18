using EducationalPlatform1._0.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform1._0.Models.Data.Config
{
    public class StudentQuizConfig : IEntityTypeConfiguration<StudentQuiz>
    {
        public void Configure(EntityTypeBuilder<StudentQuiz> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.QuizId });
            builder.Property(x => x.StudentId).ValueGeneratedNever();
            builder.Property(x => x.QuizId).ValueGeneratedNever();
            //builder.HasOne(x => x.Student).WithMany(x => x.studentQuizzes).HasForeignKey(x => x.StudentId);
            //builder.HasOne(x => x.Quiz).WithMany(x => x.studentQuizzes).HasForeignKey(x => x.QuizId);
        }
    }
}
