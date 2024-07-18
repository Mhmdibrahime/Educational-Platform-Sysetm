using EducationalPlatform1._0.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform1._0.Models.Data.Config
{
    public class GradeConfig : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.Student).WithMany(x => x.Grades).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Grades");
        }
    }
}
