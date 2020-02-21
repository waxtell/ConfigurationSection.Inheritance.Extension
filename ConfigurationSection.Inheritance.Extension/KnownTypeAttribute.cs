using System;

namespace ConfigurationSection.Inheritance.Extension
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class KnownTypeAttribute : Attribute
    {
        public Type Type { get; }
        public string Key { get; }

        public KnownTypeAttribute(Type type, string key)
        {
            Type = type;
            Key = key;
        }
    }
}
