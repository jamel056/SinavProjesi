using E.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.Infrast.Data.Configuration
{
    public class AnswersConfiguration : IEntityTypeConfiguration<Answers>
    {
        public void Configure(EntityTypeBuilder<Answers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Answer).IsRequired().HasMaxLength(100);
        }
    }
}
