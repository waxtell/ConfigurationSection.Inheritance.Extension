using System.Linq;
using System.Reflection;

namespace ConfigurationSection.Inheritance.Extension.Extensions
{
    internal static class TypeInfoExtensions
    {
        public static bool HasTypeConverterAttribute(this TypeInfo type)
        {
            return
                type
                    .GetCustomAttributes(typeof(TypeConverterAttribute), false)
                    .Any();
        }
    }
}
