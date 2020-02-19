using System;
using ConfigurationSection.Inheritance.Extension;

namespace SampleApp9000
{
    [KnownType(typeof(Rectangle), "rectangle")]
    [KnownType(typeof(Square), "square")]
    [KnownType(typeof(Circle), "circle")]
    [ConfigurationSectionTypeConverter("type")]
    public abstract class Shape
    {
        public abstract double Area { get; }

        public abstract double Perimeter { get; }

        public override string ToString() => GetType().Name;

        public static double GetArea(Shape shape) => shape.Area;

        public static double GetPerimeter(Shape shape) => shape.Perimeter;
    }

    public class Square : Shape
    {
        public double Side { get; set; }

        public override double Area => Math.Pow(Side, 2);

        public override double Perimeter => Side * 4;

        public double Diagonal => Math.Round(Math.Sqrt(2) * Side, 2);
    }

    public class Rectangle : Shape
    {
        public double Length { get; set; }

        public double Width { get; set; }

        public override double Area => Length * Width;

        public override double Perimeter => 2 * Length + 2 * Width;

        public bool IsSquare() => Length == Width;

        public double Diagonal => Math.Round(Math.Sqrt(Math.Pow(Length, 2) + Math.Pow(Width, 2)), 2);
    }

    public class Circle : Shape
    {
        public override double Area => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);

        public override double Perimeter => Math.Round(Math.PI * 2 * Radius, 2);

        public double Circumference => Perimeter;

        public double Radius { get; set; }

        public double Diameter => Radius * 2;
    }
}
