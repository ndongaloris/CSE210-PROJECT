using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        String letter;
        String plus = "+";
        String minus = "-";
        int grade = int.Parse(Console.ReadLine());
       
    //    Condition that determine you grade
        if (grade >= 90)
        {
            letter = "A";
        }else if (grade >= 80){
            letter = "B";
        }else if(grade >= 70){
            letter = "C";
        }else if(grade >=60){
            letter = "D";
        }else{
            letter = "F";
        }
        
        // condition to determine the sign of your grade
        if(grade % 10 >= 7 && grade < 97 && grade > 60){
            Console.WriteLine($"Your letter grade is {letter}{plus}.");
        }else if(grade % 10 <= 3 && grade <97 && grade >60){
            Console.WriteLine($"Your letter grade is {letter}{minus}.");
        }else{
            Console.WriteLine($"Your letter grade is {letter}.");
        }
       
       // message displaying whether you passed or not.
        if (grade >= 70){
            Console.WriteLine("Congratulation! You have passed.");
        }else{
            Console.WriteLine("I'm sorry, try again next time with the knowledge you have you will surely pass.");
        }
    }
}