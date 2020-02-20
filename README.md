# ConfigurationSection.Inheritance.Extension
Extend Microsoft.Extensions.Configuration.Binder to support inheritance (through a discriminator)

This project extends the ConfigurationBinder functionality provided by Microsoft [Microsoft.Extensions.Configuration.Binder](https://github.com/dotnet/extensions).

Please visit [LICENSE.txt](https://github.com/dotnet/extensions/blob/master/LICENSE.txt) for licensing details.

This extension allows for heterogenous collections.  Given the following appsettings.json

```
{
  "Shapes": [
    {
      "type": "circle",
      "Radius": 2.34
    },
    {
      "type": "square",
      "Side": 5.67
    },
    {
      "type": "rectangle",
      "Length": 3.14,
      "Width": 42 
    }
  ]
}
```

```csharp
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
```
