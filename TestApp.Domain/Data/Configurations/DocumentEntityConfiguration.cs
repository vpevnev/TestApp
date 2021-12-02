using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Domain.Entities;

namespace TestApp.Domain.Data.Configurations
{
    public class DocumentEntityConfiguration : IEntityTypeConfiguration<DocumentEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentEntity> builder)
        {
            builder
                .ToTable("Documents")
                .HasDiscriminator<string>("Child");

            builder
                .HasKey(e => e.DocumentId);
        }
    }
}
