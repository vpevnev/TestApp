using System;

namespace TestApp.Domain.Entities
{
    public abstract class DocumentEntity
    {
        public Guid DocumentId { get; set; }

        public short DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }

        public Guid FileEntityId { get; set; }
        public FileEntity FileEntity { get; set; }
    }
}
