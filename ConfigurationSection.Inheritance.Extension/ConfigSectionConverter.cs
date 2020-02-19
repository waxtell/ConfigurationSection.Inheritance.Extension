using System;
using System.Linq;
using ConfigurationSection.Inheritance.Extension.Extensions;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSection.Inheritance.Extension
{
    public class ConfigSectionConverter
    {
        private readonly string _discriminator;
        private readonly (Type type, string key)[] _types;

        public ConfigSectionConverter(string discriminator, params (Type type, string key)[] types)
        {
            _discriminator = discriminator;
            _types = types;
        }

        public object CreateInstance(IConfigurationSection section)
        {
            var (type, _) = _types.FirstOrDefault(x => x.key == section[_discriminator]);

            if (type != null && !type.IsAbstract && type.HasParameterlessConstructor())
            {
                return 
                    Activator
                        .CreateInstance(type);
            }

            return default;
        }

        //public T Bind(IConfigurationSection section)
        //{
        //    var (type, _) = _types.FirstOrDefault(x => x.key == section[_discriminator]);

        //    if (type != null && !type.IsAbstract && type.HasParameterlessConstructor())
        //    {
        //        var instance = Activator.CreateInstance(type);

        //        section.Bind(instance);

        //        return (T) instance;
        //    }

        //    return default;
        //}
    }
}