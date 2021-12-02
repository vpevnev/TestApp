using System.ComponentModel.DataAnnotations;

namespace TestApp.WebUI.Models
{
    public class PayerDocumentViewModel : DocumentViewModel
    {
        [Display(Name = "Рег. номер")]
        public string RegNumber { get; set; }
    }
}
