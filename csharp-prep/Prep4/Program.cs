using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine()); ;

        int num = 0;
        List<int> numbers = new List<int>();

        int largest = 0;
        int small_positive = 100000;

        while (number != 0)
        {
            numbers.Add(number);
            num += number;
            Console.Write("Please enter a number: ");
            number = int.Parse(Console.ReadLine());

        }

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > largest)
            {
                largest = numbers[i];
            }
        }

        double average = (double)num / numbers.Count;
        numbers.Sort();

        Console.WriteLine($"The sum: {num}");
        Console.WriteLine($"The average is : {average}");
        Console.WriteLine($"The largest number is : {largest}");
        foreach (int i in numbers)
        {
            if (i >= 0 && i < small_positive)
            {
                small_positive = i;
            }
        }
        Console.WriteLine($"The smallest positive number {small_positive}");
        Console.WriteLine($"The sorted list is: ");
        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }
    }
}