using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp.BusinessLogic.DataTransferObjects
{
    public class FileEntityDTO
    {
        public Guid FileEntityId { get; set; } = Guid.NewGuid();


        [MaxLength(128)]
        public string FileName { get; set; }

        public DateTime LoadTime { get; set; }

        public IFormFile FormFile { get; set; }

        public byte[] FileData { get; set; }

        public Guid ListBaseId { get; set; }
    }
}
