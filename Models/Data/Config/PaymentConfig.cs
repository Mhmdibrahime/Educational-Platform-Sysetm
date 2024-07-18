using EducationalPlatform1._0.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform1._0.Models.Data.Config
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CVV).HasMaxLength(3);
            builder.HasOne(x=>x.Student).WithMany(x=>x.Payments).HasForeignKey(x=>x.studentId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
