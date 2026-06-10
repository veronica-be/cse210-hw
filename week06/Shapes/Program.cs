using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> shapes = new List<Shape>();

        Square square = new Square("red", 55.3);
        Rectangle rectangle = new Rectangle("blue", 12, 2);
        Circle circle = new Circle("gold", 5);

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (var shape in shapes)
        {
            Console.Write("Color: " + shape.GetColor() + "     ");
            Console.WriteLine("Area:" + shape.GetArea());

        }

    }
}