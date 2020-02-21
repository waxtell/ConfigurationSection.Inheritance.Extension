using System;

namespace ConfigurationSection.Inheritance.Extension
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class TypeConverterAttribute : Attribute
    {
        public string Discriminator { get; }

        public TypeConverterAttribute(string discriminator)
        {
            Discriminator = discriminator;
        }
    }
}
