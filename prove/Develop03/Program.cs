using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture S1 = new Scripture();
        Reference R1 = new Reference();
        Word W1 = new Word();
       
        string reference = R1.GetReference("John", 3, 16);
        string reference2 = R1.GetReference("Proverb", 6, 5, 6);
        
        S1.SetReference(reference, reference2); //send the references into the scripture class
        S1.SetVerse(); //set or define the verses
        S1.GetScripture();
        
        Console.Write("How many words you want to hide? ");
        int prompt = int.Parse(Console.ReadLine());
        S1.Display(); //Display the scripture

        List<string> scripture = S1.splitIntoList(); 
        W1.GetReferenceVerse(scripture); //send the scripture form to the word class
        
        string play = "";
        while(play != "quit")
        {
            Console.Write("Press Enter to continue and type Quit to continue: ");
            play = Console.ReadLine();
            W1.HideAndShow(prompt);
        }
    }
}