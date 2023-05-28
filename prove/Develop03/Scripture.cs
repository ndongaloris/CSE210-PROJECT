//  Keeps track of the reference and the text of the scripture. Can hide words and get the rendered
public class Scripture
{
    private List<string> _scriptureList = new List<string> { };
    // store a scripture of one verse as a string
    private string _singleReference;
    // store a scripture of multiple verse as a string
    private string _multiReference;
    // store a scripture with only one verse
    private string _verse;
    // store a scripture with multiple verses
    private string _verse2;
    // store the list of the sliced verse
    private List<string> _verseList = new List<string> { };
    // contain the return random scripture chosen
    private string _chosenScripture;
    // set store the reference information into the destined attribute
    public void SetReference(string info, string info2)
    {
        _singleReference = info;
        _multiReference = info2;
    }
    // set store the verse information into the destined attribute
    public void SetVerse()
    {
        _verse = "God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        _verse2 = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
    }
    // Get the scripture and then append it to a list
    public void GetScripture()
    {
        _scriptureList.Add($"{_singleReference} {_verse}");
        _scriptureList.Add($"{_multiReference} {_verse2}");
    }
    // split a string into a list
    public List<string> splitIntoList()
    {
        string[] words = _chosenScripture.Split(" ");
        foreach (string word in words)
        {
            _verseList.Add(word);
        }
        return _verseList;
    }
    public void Display()
    {
        Random scripture = new Random();
        int scriptureIndex = scripture.Next(_scriptureList.Count()); //generate a random scripture index
        _chosenScripture = _scriptureList[scriptureIndex]; //retrieve the scripture from the index and store it into the attribute
        Console.Clear(); //clear the terminal
        Console.WriteLine(_chosenScripture);
    }
}