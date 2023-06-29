using System;
using System.Text;
using System.Collections.Generic;
//  Keeps track of the reference and the text of the scripture. Can hide words and get the rendered
public class Scripture
{   
    // store the reference
    private Reference _reference;
    // store the sliced verse 
    private List<Word> _listWords = new List<Word>{};
    // a list that track the remaining words to help not repeat hiding the same word
    private List<Word> _remainingWords = new List<Word>{};
    // set store the reference information into the destined attribute
    private string _chosenScripture;
    public Scripture(string verse, Reference reference)
    {
        _reference = reference; //set the reference
        _chosenScripture = verse; //set the verse
        string[] words = _chosenScripture.Split(" "); //sliced the verse into multiple string to
        foreach (string word in words)
        {
            _listWords.Add(new Word(word)); // append the sliced verse into the _listWords
            _remainingWords.Add(new Word(word)); // append the sliced verse into the _remainingWords to be tracked
        }
    }    
    public int NumWordToHide(int numWordToHide) 
    {
        int remainingWords = 0;
        for(int k = 0; k < _listWords.Count(); k++)
        {
            if (_listWords[k].GetVisibility() == false ) //handle the case where the number of of words left to be listed less, and prevent the code to crash
            {
                remainingWords++;
            }
        }
        if (remainingWords < numWordToHide)
        {
            numWordToHide = remainingWords;
        }
        if (numWordToHide == 0)
        {
            Environment.Exit(1);
        }
        return numWordToHide;
    }
    public void HideAndShow(int numWordToHide)
    {
        int times = NumWordToHide(numWordToHide);
        Random random = new Random();
        for (int i = 0; i < times; i++)
        {
            int index = random.Next(_listWords.Count);
            while(_listWords[index].GetVisibility() == true)
            {
                index = random.Next(_listWords.Count);
            }
            _listWords[index].Hide();
            _listWords[index].Visibility();
        }
    }
   
   public void Display()
   {
        StringBuilder stringBuilder =  new StringBuilder();
        foreach (Word word in _listWords)
        {
            stringBuilder.Append(word.Visibility());
            stringBuilder.Append(" ");
        }
        _chosenScripture = stringBuilder.ToString().Trim(); //return the _listWords content as a string (sentence)
        Console.Clear();
        Console.WriteLine($"{_reference.GetReference()} {_chosenScripture}");
   }
}
