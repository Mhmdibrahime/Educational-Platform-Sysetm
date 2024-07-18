using EducationalPlatform1._0.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform1._0.Models.Data.Config
{
    public class QuizConfig : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Title).HasColumnType("varchar").HasMaxLength(255);
            //builder.HasMany(x => x.Students).WithMany(x => x.Quizzes).UsingEntity<StudentQuiz>();
            builder.HasMany(q => q.studentQuizzes)
              .WithOne(sq => sq.Quiz)
              .HasForeignKey(sq => sq.QuizId);

        }
    }
}
