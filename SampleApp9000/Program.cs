using System;
using System.Collections.Generic;
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
            
            var shapes = config
                            .GetSection("Shapes")
                            .GetEx<List<Shape>>();

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Type: {shape}");
                Console.WriteLine($"  Area: {shape.Area}");
                Console.WriteLine($"  Perimeter: {shape.Perimeter}");
            }

            // Type: Circle
            //   Area: 17.2
            //   Perimeter: 14.7
            // Type: Square
            //   Area: 32.1489
            //   Perimeter: 22.68
            // Type: Rectangle
            //   Area: 131.88
            //   Perimeter: 90.28
        }
    }
}
