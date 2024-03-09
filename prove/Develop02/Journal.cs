using System;
using System.IO;

class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public string _currentFileName = "";

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry e in _entries)
        {
            Console.WriteLine();
            e.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry e in _entries)
            {
                //outputFile.WriteLine($"Date: {e._date} - Prompt: {e._promptText}");
                //outputFile.WriteLine($"{e._entryText}\n");

                outputFile.WriteLine($"{e._date}|{e._promptText}|{e._entryText}");
            }
        }
        Console.WriteLine($"Successfully saved: {file}");
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();

        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            Entry newEntry = new Entry();
            string[] parts = line.Split("|");
            newEntry._date = parts[0];
            newEntry._promptText = parts[1];
            newEntry._entryText = parts[2];  
            AddEntry(newEntry);
        }
    }
}