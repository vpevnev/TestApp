using System;

namespace TestApp.BusinessLogic.Infrastructure.Attributes
{
    /// <summary>
    /// Атрибут настройки отображения свойств класса
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class VisibleAttribute : Attribute
    {
        public bool Hidden { get; set; }
        public byte Order { get; set; }
        public bool Render { get; set; } = true;

        public VisibleAttribute()
        { }
    }
}
