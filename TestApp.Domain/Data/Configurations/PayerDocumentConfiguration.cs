using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Domain.Entities;

namespace TestApp.Domain.Data.Configurations
{
    public class PayerDocumentConfiguration : IEntityTypeConfiguration<PayerDocument>
    {
        public void Configure(EntityTypeBuilder<PayerDocument> builder)
        {
            builder
                .HasIndex(e => new { e.RegnCode, e.DistCode, e.InsrNumber })
                .HasDatabaseName("IX_PayerDocument_RegNumber")
                .IsUnique(false);
        }
    }
}
