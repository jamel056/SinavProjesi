using E.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.Infrast.Data.Configuration
{
    public class QuestionsConfiguration : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Question).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.Answers).WithOne(x => x.Questions).HasForeignKey(x => x.QuestionId);
        }
    }
}
