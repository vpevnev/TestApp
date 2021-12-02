using System.ComponentModel.DataAnnotations;

namespace TestApp.BusinessLogic.BusinessModels.Enums
{
    /// <summary>
    /// Категории лиц страхователя
    /// </summary>
    public enum PayerPersonCategory
    {
        /// <summary>
        /// Физическое лицо
        /// </summary>
        [Display(Name = "Физическое лицо")]
        Individual,
        /// <summary>
        /// Руководитель
        /// </summary>
        [Display(Name = "Руководитель")] 
        Boss,
        /// <summary>
        /// Бухгалтер
        /// </summary>
        [Display(Name = "Бухгалтер")] 
        Bookkeeper
    }
}
