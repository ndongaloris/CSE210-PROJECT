// Keeps track of the book, chapter, and verse information.
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseInfo;
    private int _verseInfo2;
    public Reference(string book, int chapter, int verse)
    {
        // manage the reference:
        // if there is only one verse for the scripture 
        {
            _book = book; _chapter = chapter; _verseInfo = verse;
        }
    }
    public Reference(string book, int chapter, int verse, int verse2 = 0)
    {
        // manage the reference:
        // if there is only multiverse verse for the scripture 
        {
            _book = book; _chapter = chapter; _verseInfo = verse; _verseInfo2 = verse2;
        }
    }
    public string GetReference()
    {
        // set the verse format.
        if (_verseInfo2 == 0)
        {
            string Ref = $"{_book} {_chapter}:{_verseInfo}";
            return Ref;
        }
        else
        {
            string Ref = $"{_book} {_chapter}:{_verseInfo}-{_verseInfo2}";
            return Ref;
        }
    }

}