using AHY.ToDoAppNTier.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AHY.ToDoAppNTier.DataAccess.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Definition)
                .HasMaxLength(300)
                .IsRequired(true);

            builder.Property(x => x.IsCompleted).IsRequired(true);

        }
    }
}
