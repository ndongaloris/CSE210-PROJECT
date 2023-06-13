using System.Runtime.CompilerServices;
using System.Net;
using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>(){};
        
        Square sqr = new Square("pink", 4);

        Circle crcl = new Circle("Black", 6);

        Rectangle rctgl = new Rectangle("Red", 5, 8);
        
        shapes.Add(sqr);
        shapes.Add(crcl);
        shapes.Add(rctgl);

        foreach (Shape shp in shapes)
        {
            Console.WriteLine(shp.GetColor());
            Console.WriteLine(shp.GetArea());

        }
    }
}