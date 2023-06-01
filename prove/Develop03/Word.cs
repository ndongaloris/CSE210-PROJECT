using System;
//  Keeps track of a single word and whether it is shown or hidden.
public class Word
{
    // store the reference as a string
    private bool _hidden = false;
    // contains the sliced scripture
    private string _scripture;
    // contain the sliced version of the verse
    public Word(string word)
    {
        _scripture = word;
    }
    public void hide() 
    {
        // change the _hidden attribute when it's true
        _hidden = true;
    }
    public string visibility()
    {

        // define the visibility and change the word to "_" if _hidden is true
        if (_hidden)
        {
            return _scripture = new string('_', _scripture.Count());
        }
        else
        {
            return _scripture;

        }
    }
}