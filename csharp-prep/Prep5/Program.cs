using System;

class Program
{
    static void Main(string[] args)
    {
        Display_Welcome();
        string name = Prompt_User_Name();
        int number = Prompt_User_Number();
        int square = Square_Number(number);
        Display_Result(name, square);
    }
    static void Display_Welcome()
    {
        Console.WriteLine("Welcome to the program");
    }
    static string Prompt_User_Name()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int Prompt_User_Number()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int Square_Number(int number)
    {
        int square = (int)Math.Pow(number, 2);
        return square;
    }
    static void Display_Result(string name, int square)
    {
        Console.WriteLine($"{name}, the square of you number is {square}");
    }
}