using System;

// ReSharper disable once CheckNamespace
namespace ConfigurationSection.Inheritance.Extension
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
