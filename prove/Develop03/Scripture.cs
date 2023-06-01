//  Keeps track of the reference and the text of the scripture. Can hide words and get the rendered
public class Scripture
{   
    // store the reference
    private Reference _reference;
    // store the sliced verse 
    private List<string> _listWords = new List<string>{};
    // a list that track the remaining words to help not repeat hiding the same word
    private List<string> _remainingWords = new List<string>{};
    // set store the reference information into the destined attribute
    private string _chosenScripture;
    public Scripture(string verse, Reference reference)
    {
        _reference = reference; //set the reference
        _chosenScripture = verse; //set the verse
        string[] words = _chosenScripture.Split(" "); //sliced the verse into multiple string to
        foreach (string word in words)
        {
            _listWords.Add(word); // append the sliced verse into the _listWords
            _remainingWords.Add(word); // append the sliced verse into the _remainingWords to be tracked
        }
        
    }
    public void HideAndShow(int prompt)
    {
         if (_remainingWords.Count > 0)
        {
            int numWordToHide = prompt; // take the number of words to hide from the user and store it
            for (int i = 0; i < numWordToHide; i++)
            {
                if (numWordToHide > _remainingWords.Count()) //handle the case where the number of of words left to be listed less, and prevent the code to crash
                {
                    numWordToHide = _remainingWords.Count();
                }
                Random random = new Random();
                int RandomWord_index = random.Next(_remainingWords.Count()); //take a random index form that list
                string RandomWord = _remainingWords[RandomWord_index]; //get the random word
                _remainingWords.RemoveAt(RandomWord_index); //remove the random word from the _remainingWords list so that it will not be repeated
                Word theWord  = new Word(RandomWord); //use the Word class 
                theWord.hide(); //change the possibility of hiding the word to true
                string hiddenWord = theWord.visibility(); //return the hidden word
                for (int j = 0; j < _listWords.Count(); j++)
                {
                    // the hidden word into the _listWords to hide it
                    if (RandomWord == _listWords[j]){
                        _listWords[j] = hiddenWord;
                    }
                }
           }
        }

        else
        {
            System.Environment.Exit(1); //stop the program when all the word has been hidden
        }
    }
   public void Display()
   {
        _chosenScripture = string.Join(" ", _listWords); //return the _listWords content as a string (sentence)
        Console.Clear();
        Console.WriteLine($"{_reference.GetReference()} {_chosenScripture}");

   }
    
}