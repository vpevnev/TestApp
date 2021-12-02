using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Domain.Entities
{
    public class DocumentType
    {
        public short DocumentTypeId { get; set; }

        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string ShortName { get; set; }

        public IEnumerable<DocumentEntity> Documents { get; set; }
    }
}