using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Car_Shop.Domain.Extensions
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this System.Enum enumValur)
        {
            return enumValur.GetType().GetMember(enumValur.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.GetName() ?? "Неопределенный";
        }
    }
}
