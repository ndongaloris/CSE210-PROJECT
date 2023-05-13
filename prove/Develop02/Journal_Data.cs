public class journalData
{
    public string _fileName;
    public string _fileFormat;
    public string _format;
    public string _data;

    public void saveFile(List<string> instance)
    //create, save and add if the file exist in the path or
    //write in that file
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
       
        if (File.Exists(_fileFormat)) //check if the file exist.
        {
            using (StreamWriter out_put_file = File.AppendText(_fileFormat))
            {
                foreach (string data in instance)
                {
                    out_put_file.WriteLine(data);
                }

            }
        }
        else
        {
            using (StreamWriter out_put_file = new StreamWriter(_fileFormat))
            {
                foreach (string data in instance)
                {
                    out_put_file.WriteLine($"{data}");
                }

            }
        }
    }
    public void loadFile(List<string> instance)
    //load the file and append what is store in the file to the _entry list so it can be display
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
        // _fileFormat = Console.ReadLine(); 
        using (StreamReader read = new StreamReader(_fileFormat))
        {
            _data = read.ReadToEnd();// read until the last line of a file and store the content into a variable
            instance.Clear(); // clear everything that is in the list before adding something
            instance.Add(_data); //load(add) all the data into the list of _entry
        }
    }

}