using System;

class Scripture
{
    private Reference _reference = new Reference(" ",0,0);
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numToHide)
    {
        if (IsCompletelyHidden() == false)
        {
            List<int> indexOfNotHidden = new List<int>();

            for (int i = 0; i < _words.Count(); i++)
            {
                if (_words[i].IsHidden() == false)
                {
                    indexOfNotHidden.Add(i);
                }
            }

            // if the count of not hidden words is <= the amount 
            // required to hide, we don't need random, just hide all
            if (indexOfNotHidden.Count() <= numToHide)
            {
                // Hide all the rest
                foreach (int i in indexOfNotHidden)
                {
                    _words[i].Hide();
                }
            }
            else // if the count of not hidden words is > numToHide
            {
                // Hide numToHide random words
                Random rand = new Random();
                
                for (int i = 0; i < numToHide; i++)
                {
                    int rndIndex = rand.Next(indexOfNotHidden.Count());
                    _words[indexOfNotHidden[rndIndex]].Hide();
                    indexOfNotHidden.RemoveAt(rndIndex);
                }
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetDisplayText()} ";

        foreach (Word word in _words)
        {
           displayText = displayText + word.GetDisplayText() + " "; 
        }

        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        bool isCompletelyHidden = true;

        for (int i = 0; i < _words.Count(); i++)
        {
            if (_words[i].IsHidden() == false)
            {
                isCompletelyHidden =  false;
            }
        }
        return isCompletelyHidden;
    }
}