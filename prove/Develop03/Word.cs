using System;
//  Keeps track of a single word and whether it is shown or hidden.
public class Word
{
    // store the reference as a string
    private string Reference;
    private string _randomWords;
    private int _index;
    // contains the sliced scripture
    private List<string> _scripture = new List<string> { };
    // contain the sliced version of the verse
    private List<string> _versePart = new List<string> { };
    // deal with hidden words so that it will not repeat
    private List<int> _remainingWords = new List<int> { };
    public void GetReferenceVerse(List<string> scripture)
    {
        _scripture = scripture;
        // for the reference part
        int startReference = 0;
        int endReference = 2;
        List<string> referencePart = _scripture.GetRange(startReference, endReference); //method that get the range of element in a list 
        Reference = string.Join(" ", referencePart);

        // for the verse part
        int startVerse = 2;
        int endVerser = _scripture.Count() - endReference;
        _versePart = _scripture.GetRange(startVerse, endVerser);//method that get the range of element in a list

        _remainingWords = Enumerable.Range(0, _versePart.Count).ToList(); //Generates a sequence of integral numbers within a specified range and put it in a list format.
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
                _index = random.Next(_remainingWords.Count()); // retrieve a random index for the list
                int chosenIndex = _remainingWords[_index]; //retrieve the value of that index
                _remainingWords.RemoveAt(_index); //remove that string from the list so that it won't be repeated

                _randomWords = _versePart[chosenIndex];
                _versePart[chosenIndex] = new string('_', _randomWords.Count());
            }

            Console.Clear();
            Console.WriteLine($"{Reference} {string.Join(" ", _versePart)}");
        }
        else
        {
            System.Environment.Exit(1); //stop the program when all the word has been hidden
        }
    }
}