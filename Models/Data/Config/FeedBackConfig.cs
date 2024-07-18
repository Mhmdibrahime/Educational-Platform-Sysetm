using EducationalPlatform1._0.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform1._0.Models.Data.Config
{
    public class FeedBackConfig : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.HasKey(x => x.Id);  
            builder.HasOne(x=>x.student).WithMany(x=>x.FeedBacks).HasForeignKey(x=>x.StudentId);
        }
    }
}
