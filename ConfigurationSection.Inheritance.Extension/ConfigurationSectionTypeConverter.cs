using System;

namespace ConfigurationSection.Inheritance.Extension
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ConfigurationSectionTypeConverterAttribute : Attribute
    {
        public string Discriminator { get; }

        public ConfigurationSectionTypeConverterAttribute(string discriminator)
        {
            Discriminator = discriminator;
        }
    }
}
