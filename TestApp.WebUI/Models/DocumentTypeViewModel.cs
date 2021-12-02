using System.ComponentModel.DataAnnotations;

namespace TestApp.WebUI.Models
{
    [Display(Name = "Тип документа")]
    public class DocumentTypeViewModel
    {
        public short DocumentTypeId { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Краткое наименование")]
        public string ShortName { get; set; }
    }
}
