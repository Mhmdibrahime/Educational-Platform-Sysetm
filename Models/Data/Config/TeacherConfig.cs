using EducationalPlatform1._0.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform1._0.Models.Data.Config
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();
            

        }
    }
}
