using System;


class Program
{
    static void Main(string[] args)
    {
        List<string> ReferenceList = new List<string>{};

        string verse1 = "God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        string verse2 = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        
        Reference reference;
        // define the verses to use
        Reference R1 = new Reference("John", 3, 16);
        Reference R2 = new Reference("Proverb", 6, 5, 6);

        // Append the verse in the ReferenceList
        ReferenceList.Add(R1.GetReference());
        ReferenceList.Add(R2.GetReference());
        string verse = "";
        
        // call a random verse from the ReferenceList
        Random random  = new Random();
        int Ref = random.Next(ReferenceList.Count());

        // determine which verse to use
        if (Ref == 0)
        {
            reference = R1;
            verse = verse1;
        }
        else
        {
            reference = R2;
            verse = verse2;
        }
        

        Console.Clear(); 
        
        string play = "";
        Scripture S1 = new Scripture(verse, reference);
        S1.Display(); //display the scripture without any change
        Console.Write("How many number do you want to hide at a time: "); 
        int numToHide = int.Parse(Console.ReadLine());

        while (play != "quit")
        {
            Console.Write("Press Enter to continue and type Quit to continue: ");
            play = Console.ReadLine();
            S1.HideAndShow(numToHide); //hide the word
            S1.Display(); //display with the changes
        }
    }
}