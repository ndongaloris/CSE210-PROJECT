public class journalEntry
{
    public int _count = 0;
    // an empty list to store data
    public List<string> _entries = new List<string> { };
    // a list of prompts that will be stored in the entry list
    // with the user input

    public void entryDisplay()
    {
        foreach (string data in _entries)
        {
            Console.WriteLine(data);// //display everything store into the _entry list
        }
    }
    public void addEntry(string sentence, string prompt, string title, string author, string goal)
    {
        if (_count == 0) //so that it will not ask for the title every time you writing at the same time in the file.
        {
            if (title == null) //if there is nothing store in the title, it will pass and not write anything.
            {
                { };
            }
            else
            {
                //add the title and the name of the user into the _entry list
                _entries.Add($"{' ',-25}Title: {title}\n");
                _entries.Add($"By {author}\n");
                _count++;
            }
        }

        if (sentence == null) // if there is nothing store as a sentence, it will pass and not write anything.
        {
            { };
        }
        else
        {
            // add the prompt and the sentence to the _entry list
            _entries.Add($"{"Prompt:",8}\n{" ",-7}{prompt}");
            _entries.Add($"{"Answer:",8}\n{" ",-7}{sentence}\n");
        }

        if (goal == null)
        {
            { };
        }
        else
        {
            _entries.Add($"{' ',-25}GOAL: \n{goal,25}\n"); // create a space and write the the title goal
        }
        _entries.Add($"Date and time: {DateTime.Now,-30}"); // add the date and time to the _entry list

    }

}