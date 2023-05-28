    // Keeps track of the book, chapter, and verse information.
public class Reference
{
    private string _Book;
    private int _Chapter;
    private int _verseInfo;
    private int _verseInfo2;
    public string GetReference(string book, int chapter, int verse, int verse2 = 0)
    {
        // manage the reference:
        // if there is only one verse for the scripture or two
        if (verse2 == 0)
        {
            _Book = book; _Chapter = chapter; _verseInfo = verse;
            string Ref = $"{_Book} {_Chapter}:{_verseInfo}";
            return Ref;
        }
        else
        {
            _Book = book; _Chapter = chapter; _verseInfo = verse; _verseInfo2 = verse2;
            string Ref = $"{_Book} {_Chapter}:{_verseInfo}-{_verseInfo2}";
            return Ref;
        }
    }
}