using System;

namespace TestApp.BusinessLogic.DataTransferObjects
{
    public abstract class DocumentEntityDTO
    {
        public Guid DocumentId { get; set; }

        public string ClientDocumentName { get; set; }

        public short DocumentTypeId { get; set; }
        public DocumentTypeDTO DocumentType { get; set; }

        public Guid FileEntityId { get; set; }
        public FileEntityDTO FileEntity { get; set; }
    }
}
