using System;
public class JournalEntry
{
    public int _count = 0;
    public string _prompt;
    public string _answer;
    public string _date; 
    public string _title;
    public string _author;
    public string _goal;
    // an empty list to store data
    // public List<string> _entries = new List<string> { };
    // a list of prompts that will be stored in the entry list
    // with the user input

    public void SetEntry(string title,string author, string prompt,string answer, string goal)
    {
        _prompt = prompt;
        _answer = answer;
        _title = title;
        _author = author;
        _goal =  goal;
        _date = DateTime.Now.ToString();

    }
    public string GetEntry()
    {
        return ($"Title - {_title}\n" +
                $"By - {_author}\n" +
                $"Prompt - {_prompt}\n" +
                $"Answer - {_answer}\n" +
                $"GOAL - {_goal}\n" +
                $"Date and time - {_date}\n");
    }
    public void Display()
    {
        Console.WriteLine(GetEntry());
    }
}
   

