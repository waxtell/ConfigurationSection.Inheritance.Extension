using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace ConfigurationSection.Inheritance.Extension
{
    public class ConverterFactory
    {
        public static ConfigSectionConverter<TTarget> Create<TTarget>()
        {
            var targetType = typeof(TTarget);

            var typeConverter = targetType
                                    .GetCustomAttributes(typeof(ConfigurationSectionTypeConverterAttribute), false)
                                    .FirstOrDefault();

            if (typeConverter != null)
            {
                var knownTypes = targetType
                                    .GetCustomAttributes(typeof(KnownTypeAttribute), false)
                                    .Cast<KnownTypeAttribute>()
                                    .Select(x => (x.Type, x.Key))
                                    .ToArray();

                return 
                    (ConfigSectionConverter<TTarget>)
                        Activator
                            .CreateInstance
                            (
                                typeof(ConfigSectionConverter<>).MakeGenericType(targetType),
                                BindingFlags.CreateInstance,
                                null,
                                new object[]
                                {
                                    ((ConfigurationSectionTypeConverterAttribute) typeConverter).Discriminator,
                                    knownTypes
                                }, CultureInfo.CurrentCulture
                            );
            }

            return null;
        }
    }
}