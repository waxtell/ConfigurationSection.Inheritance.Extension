using System;
using System.Linq;
using System.Reflection;

namespace ConfigurationSection.Inheritance.Extension.Extensions
{
    internal static class TypeExtensions
    {
        public static bool HasParameterlessConstructor(this Type type)
        {
            return 
                type.IsValueType || type.GetConstructor(Type.EmptyTypes) != null;
        }

        public static bool HasTypeConverterAttribute(this TypeInfo type)
        {
            return
                type
                    .GetCustomAttributes(typeof(TypeConverterAttribute), false)
                    .Any();
        }
    }
}
