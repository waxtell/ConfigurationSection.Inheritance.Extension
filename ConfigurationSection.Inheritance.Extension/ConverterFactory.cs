using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace ConfigurationSection.Inheritance.Extension
{
    public class ConverterFactory
    {
        public static ConfigSectionConverter Create(Type targetType)
        {
            var typeConverter = targetType
                                    .GetCustomAttributes(typeof(TypeConverterAttribute), false)
                                    .FirstOrDefault();

            if (typeConverter != null)
            {
                var knownTypes = targetType
                                    .GetCustomAttributes(typeof(KnownTypeAttribute), false)
                                    .Cast<KnownTypeAttribute>()
                                    .Select(x => (x.Type, x.Key))
                                    .ToArray();

                return 
                    (ConfigSectionConverter)
                        Activator
                            .CreateInstance
                            (
                                typeof(ConfigSectionConverter),
                                BindingFlags.CreateInstance,
                                null,
                                new object[]
                                {
                                    ((TypeConverterAttribute) typeConverter).Discriminator,
                                    knownTypes
                                }, CultureInfo.CurrentCulture
                            );
            }

            return null;
        }
    }
}