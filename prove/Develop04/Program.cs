using System;

class Program
{
    static void Main(string[] args)
    {
        Activity A1 = new Activity();
        int _nBreathing = 0;
        int _nReflecting = 0;
        int _nListing = 0;
        int choice = 0;
        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options: \n   1.Start Breathing Activity \n   2.Start Reflecting Activity \n   3.Start Listing Activity \n   4.Quit");
            Console.Write("Select your choice from the menu: ");
            choice = int.Parse(Console.ReadLine());
            string description = "";
            string option = "";
            switch (choice)
            {
                case 1:
                    option = "Breathing Activity";
                    description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
                    Console.WriteLine();
                    Breathing b1 = new Breathing(option, description);
                    b1.GetIntroPrompt();
                    b1.InAndOut();
                    b1.GetClosingMessage();
                    _nBreathing += 1;
                    break;

                case 2:
                    option = "Reflecting Activity";
                    description = "This activity will help you reflect on times on your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other  aspects of your life.";
                    Console.WriteLine();
                    Reflection r1 = new Reflection(option, description);
                    r1.GetIntroPrompt(); 
                    r1.GetPrompt();
                    r1.GetQuestion();
                    r1.GetClosingMessage();
                    _nReflecting += 1;
                    break;

                case 3:
                    option = "Listing Activity";
                    description = "This activity will help you reflect on the good things in your life bt having you list as many thing as you can in certain areas.";
                    Console.WriteLine();
                    Listing l1 = new Listing(option, description);
                    l1.GetIntroPrompt();
                    l1.GetQuestion();
                    l1.GetClosingMessage();
                    _nListing +=1;
                    break;

                default:
                    break;
            }
        }
        A1.History(_nBreathing, _nReflecting, _nListing);

    }
}
