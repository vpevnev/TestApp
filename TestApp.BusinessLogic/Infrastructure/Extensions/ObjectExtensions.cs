using System;

namespace TestApp.BusinessLogic.Infrastructure.Extentions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Преобразует представление числа в виде базового типа object в эквивалентное ему 32-битовое целое число, допускающее значение null
        /// </summary>
        public static int? TryGetInt(this object item)
        {
            bool success = int.TryParse(item.ToString(), out int i);
            return success ? i : null;
        }

        public static DateTime? TryGetDateTime(this object item)
        {
            bool success = DateTime.TryParse(item.ToString(), out DateTime i);
            return success ? i : null;
        }

        public static bool? TryGetBool(this object item)
        {
            bool? i;

            if (item.ToString().ToLower() == "да" || item.ToString().ToLower() == "есть")
            {
                i = true;
            }
            else
            {
                i = false;
            }

            return i;
        }

        /// <summary>
        /// Преобразует логическое значение в эквивалентную строку на кириллице
        /// </summary>
        public static string TryBoolToRussianString(this object item)
        {
            string value = null;

            if (item is bool)
            {
                if (item.ToString() == "True")
                    value = "Да";
                else if (item.ToString() == "False")
                    value = "Нет";
            }

            return value;
        }
    }
}
