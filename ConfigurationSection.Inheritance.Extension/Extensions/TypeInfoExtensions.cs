using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace ConfigurationSection.Inheritance.Extension
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
