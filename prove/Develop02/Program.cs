using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal program");

        journalEntry storeData = new journalEntry();
        promptGenerator prompting = new promptGenerator();
        journalData fileName1 = new journalData();
        while (true)
        {
            Console.WriteLine("Please select one of the following:");
            Console.WriteLine($"1. Write \n2. Display \n3. Load \n4. Save \n5. Quit");
            Console.Write("What would you like to do? ");  
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                if (storeData._count == 0)
                {
                    prompting.moreInfo();
                }

                prompting.promptsDisplay();
                storeData.addEntry(prompting._sentence, prompting._prompt, prompting._title, 
                                prompting._author, prompting._goal);
            }
            else if (choice == 2)
            {
                storeData.entryDisplay();
            }
            else if (choice == 3)
            {

                fileName1.loadFile(storeData._entries);
            }
            else if (choice == 4)
            
            {
                prompting.goals();
                storeData.addEntry(prompting._sentence, prompting._prompt, prompting._title, 
                                    prompting._author, prompting._goal); //call twice to make sure that the goals are saved into the file
                fileName1.saveFile(storeData._entries);
            }
            else if (choice == 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Sorry, please select one of the numbers display in the menu \n");
            }
        }
    }
}