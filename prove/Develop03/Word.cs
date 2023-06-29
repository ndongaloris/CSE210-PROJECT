using System;
//  Keeps track of a single word and whether it is shown or hidden.
public class Word
{
    // store the reference as a string
    private bool _hidden = false;
    // contains the sliced scripture
    private string _word;
    // contain the sliced version of the verse
    public Word (string word) {
        _word = word;
    } 
    public bool Hide() 
    {
        // change the _hidden attribute when it's true
        return _hidden = true;
    }
    public bool GetVisibility()
    {
        return _hidden;
    }
    public string Visibility()
    {

        // define the visibility and change the word to "_" if _hidden is true
        if (_hidden)
        {
            return new string('_', _word.Count());
        }
        else
        {
            return _word;

        }
    }
}