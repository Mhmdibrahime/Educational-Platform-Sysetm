using EducationalPlatform1._0.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform1._0.Models.Data.Config
{
    public class StudentAnswerConfig : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Student).WithMany(x=>x.StudentAnswers).HasForeignKey(x=>x.StudentId);
            builder.HasOne(x=>x.Question).WithMany(x=>x.StudentAnswers).HasForeignKey(x=>x.QuestionId);
            builder.HasOne(x=>x.Quiz).WithMany(x=>x.studentAnswers).HasForeignKey(x=>x.QuizId).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("StudensAnswers");
        }
    }
}
