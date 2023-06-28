using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Looks like there are few things missing from the specs. 
        // In the JournalEntry class you have a list of strings for the entries 
        // but it should have attributes for the prompt, response and the date.
        //  The JournalData class should have a List of JournalEntry objects with 
        // functions to add an entry and display all then entries along with the load 
        // and save functions that you have. All of your classes and functions should use 
        // Titlee Case so JournalEntry should be JournalEntry.
        Console.WriteLine("Welcome to the Journal program");

        JournalEntry storeData = new JournalEntry();
        PromptGenerator prompting = new PromptGenerator();
        JournalData fileName1 = new JournalData();
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
                    prompting.MoreInfo();
                }
                prompting.PromptsDisplay();
                storeData.SetEntry(prompting._sentence, prompting._prompt, prompting._title, 
                                prompting._author, prompting._goal);
                fileName1.AddEntry(storeData);
            }
            else if (choice == 2)
            {
                fileName1.EntryDisplay();
            }
            else if (choice == 3)
            {

                fileName1.LoadFile();
            }
            else if (choice == 4)
            {
                prompting.Goals();
                storeData.SetEntry(prompting._title,prompting._author, prompting._prompt, prompting._sentence, prompting._goal); //call twice to make sure that the goals are saved into the file
                fileName1.SaveFile();
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