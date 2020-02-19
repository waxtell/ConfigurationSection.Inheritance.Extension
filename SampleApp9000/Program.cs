﻿using System;
using System.IO;
using ConfigurationSection.Inheritance.Extension;
using Microsoft.Extensions.Configuration;

namespace SampleApp9000
{
    public class Program
    {
        public static void Main(string[] _)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(@"appsettings.json");

            var config = builder.Build();

            var converter = ConverterFactory.Create<Shape>();

            foreach (var child in config.GetSection("Shapes").GetChildren())
            {
                var shape = converter.Bind(child);

                Console.WriteLine($"Type:  {shape}");
                Console.WriteLine($"Area: {shape.Area}");
                Console.WriteLine($"Perimeter: {shape.Perimeter}");
            }
        }
    }
}
