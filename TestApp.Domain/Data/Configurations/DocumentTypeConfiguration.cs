using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Domain.Entities;

namespace TestApp.Domain.Data.Configurations
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder
                 .HasComment("Типы документов");

            builder
                .HasData(
                    new DocumentType[]
                    {
                        new DocumentType { DocumentTypeId = 1, Name = "Акт о проведении проверки", ShortName = "Акт" },
                        new DocumentType { DocumentTypeId = 2, Name = "Справка об оказании услуг", ShortName = "Справка" },
                        new DocumentType { DocumentTypeId = 3, Name = "Документ о документе 1", ShortName = "Документ 1" },
                        new DocumentType { DocumentTypeId = 4, Name = "Документ о документе 2", ShortName = "Документ 2" },
                        new DocumentType { DocumentTypeId = 5, Name = "Документ о документе 3", ShortName = "Документ 3" }
                    });
        }
    }
}
