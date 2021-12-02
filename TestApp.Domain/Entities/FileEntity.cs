using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Domain.Entities
{
    public class FileEntity
    {
        public Guid FileEntityId { get; set; }


        [MaxLength(128)]
        public string FileName { get; set; }

        public DateTime LoadTime { get; set; }

        public byte[] FileData { get; set; }

        
        public DocumentEntity Document { get; set; }
    }
}
