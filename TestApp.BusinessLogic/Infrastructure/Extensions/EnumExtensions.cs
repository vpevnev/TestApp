using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace TestApp.BusinessLogic.Infrastructure.Extensions
{
    public static class EnumExtensions
    {

        public static string GetDisplayName(this Enum enumValue)
        {
            MemberInfo[] memberInfo = enumValue.GetType().GetMember(enumValue.ToString());

            Type attributeType = typeof(DisplayAttribute);

            object[] attributes = memberInfo[0].GetCustomAttributes(attributeType, false);

            var attribute = attributes.SingleOrDefault() as DisplayAttribute;

            return attribute?.Name;
        }
    }
}
