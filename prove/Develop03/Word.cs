class Word 
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string hiddenWord = "";
             
            foreach (char i in _text)
            {
                hiddenWord += "_";
            }

            return hiddenWord;
        }
        else
        {
            return _text;
        }
    }
}