class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }
    
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {

        string refText;

        if (_startVerse == _endVerse)
        {
            refText = $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            refText = $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }

        return refText;
    }
}