using EducationalPlatform1._0.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform1._0.Models.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();
            builder.HasMany(s => s.studentQuizzes)
               .WithOne(sq => sq.Student)
               .HasForeignKey(sq => sq.StudentId);
        }
    }
}
