using EducationalPlatform1._0.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform1._0.Models.Data.Config
{
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x=>x.)
            builder.HasOne(x=>x.Quiz).WithMany(x=>x.questions).HasForeignKey(x=>x.QuizId);
        }
    }
}
