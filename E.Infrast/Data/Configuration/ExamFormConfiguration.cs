using E.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.Infrast.Data.Configuration
{
    public class ExamFormConfiguration : IEntityTypeConfiguration<ExamForm>
    {
        public void Configure(EntityTypeBuilder<ExamForm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FormQuestion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FormText).IsRequired().HasMaxLength(5000);
            builder.HasMany(x => x.Questions).WithOne(x => x.ExamForm).HasForeignKey(x => x.FormId);
        }
    }
}
