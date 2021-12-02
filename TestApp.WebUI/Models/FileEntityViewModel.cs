using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp.WebUI.Models
{
    public class FileEntityViewModel
    {
        public Guid FileEntityId { get; set; }

        [Display(Name = "Имя файла")]
        public string FileName { get; set; }

        [Display(Name = "Дата загрузки")]
        public DateTime LoadTime { get; set; }
    }
}
