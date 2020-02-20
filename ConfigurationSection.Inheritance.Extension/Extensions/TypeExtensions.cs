using System;

namespace ConfigurationSection.Inheritance.Extension.Extensions
{
    internal static class TypeExtensions
    {
        public static bool HasParameterlessConstructor(this Type type)
        {
            return 
                type.IsValueType || type.GetConstructor(Type.EmptyTypes) != null;
        }
    }
}
