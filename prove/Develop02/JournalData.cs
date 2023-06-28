using System.Collections.Generic;
public class JournalData
{
     
    public string _fileName;
    public string _fileFormat;
    public string _format;
    public string _data;
    public List<JournalEntry> _entries = new List<JournalEntry>{};
    //create, save and add if the file exist in the path or
    //write in that file
    
    public void EntryDisplay()
    {
        foreach (JournalEntry data in _entries)
        {
           data.Display();
        }
    }
     public void AddEntry(JournalEntry entries)
    {
        _entries.Add(entries);

    }
    
    public void SaveFile()
    {
        Console.Write("What is the file?\n");
        _fileName = Console.ReadLine();
        Console.Write("Please enter the file format, CSV or TXT: ");
        _format = Console.ReadLine().ToLower();
         if (_format == "txt")
        {
            _fileFormat = $"{_fileName}.txt"; //define the format to txt.
        }
        else if (_format == "csv")
        {
            _fileFormat = $"{_fileName}.csv"; //define the format to csv.
        }
      
        using (StreamWriter out_put_file = new StreamWriter(_fileFormat))
        {
            foreach (JournalEntry data in _entries)
            {
                out_put_file.WriteLine($"{data.GetEntry()}");
            }

        }
      
    }
    //load the file and append what is store in the file to the _entry list so it can be display
    public void LoadFile()
    {
        
        Console.Write("Enter the Name of the file:\n");
        _fileName = Console.ReadLine();
        Console.Write("Please enter the file format, CSV or TXT: ");
        _format = Console.ReadLine().ToLower();
         if (_format == "txt")
        {
            _fileFormat = $"{_fileName}.txt"; //load a txt file format.
        }
        else if (_format == "csv")
        {
            _fileFormat = $"{_fileName}.csv"; //load a csv file format.
        }
    
        string[] lines = File.ReadAllLines(_fileFormat);// read until the last line of a file and store the content into a variable
        _entries.Clear(); // clear everything that is in the list before adding something
        while(lines.Count() > 0)
        {
            List<string> content = new List<string>{}; 
            for(int i = 0; i < 6; i ++)
            {
                string [] data= lines[i].Split("-");
                content.Add(data[1]);
            }
            JournalEntry load = new JournalEntry();
            load.SetEntry( content[0], content[1], content[2], content[3], content[4]);
            load._date = content[5];
            lines = lines.Skip(7).ToArray();
            _entries.Add(load); //load(add) all the data into the list of _entry
            content.Clear();
                
        }
        
       
    }

}