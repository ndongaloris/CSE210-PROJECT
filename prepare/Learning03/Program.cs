using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f = new Fraction();    
        f.fraction();
        f.GetFractionString();
        Console.WriteLine(f.GetDecimalValue());
        
        Fraction f1 = new Fraction();
        f1.fraction(5);
        f1.GetFractionString();
        Console.WriteLine(f1.GetDecimalValue());
        
        Fraction f2 = new Fraction();
        f2.fraction(3,4);
        f2.GetFractionString();
        Console.WriteLine(f2.GetDecimalValue());
       
        Fraction f3 = new Fraction();
        f3.fraction(1,3);
        f3.GetFractionString();
        Console.WriteLine(f3.GetDecimalValue());
    }
}