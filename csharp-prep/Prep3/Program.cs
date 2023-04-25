using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Guess the magic number: ");

        Random number = new Random();
        double magic_number = number.Next(1, 100);
        int i = 0;

        while (true)
        {
            Console.Write("What is your guess: ");
            double guess_number = double.Parse(Console.ReadLine());
            i++;

            if (guess_number > magic_number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess_number < magic_number)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it");
                Console.WriteLine($"It took you {i} guesses");
                Console.Write("Do you want to play agin? Enter Y for yes and N for no: ");
                string play_again = Console.ReadLine().ToUpper();
                if (play_again == "Y")
                {
                    magic_number = number.Next(1, 100);
                    continue;
                }
                else
                {
                    Console.WriteLine("Thanks for playing, see you next time!");
                    break;
                }

            }
        }
    }
}