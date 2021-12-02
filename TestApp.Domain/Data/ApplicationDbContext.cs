using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Data.Configurations;
using TestApp.Domain.Entities;

namespace TestApp.Domain.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PayerDocument> PayerDocuments { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<FileEntity> FileEntities { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DocumentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PayerDocumentConfiguration());

            modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
        }
    }
}