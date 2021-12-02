using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp.WebUI.Models
{
    public class DocumentViewModel
    {
        public Guid DocumentId { get; set; }

        [Display(Name = "Наименование документа")]
        public string ClientDocumentName { get; set; }

        public short DocumentTypeId { get; set; }
        public DocumentTypeViewModel DocumentType { get; set; }

        public Guid FileEntityId { get; set; }
        public FileEntityViewModel FileEntity { get; set; }
    }
}
