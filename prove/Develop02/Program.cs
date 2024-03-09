using System;
using System.Configuration.Assemblies;
using System.Data;
using System.Linq.Expressions;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        
        Journal myJournal = new Journal();
        
        bool isFinished = false;
        bool isSaved = true;
        string userResponse = "";
        
        do 
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            userResponse = Console.ReadLine();

            switch (userResponse)
            {
                case "1": //Write
                    CreateNewJournalEntry(myJournal);
                    isSaved = false;
                    break;
                case "2": //Display
                    myJournal.DisplayAll();
                    break;
                case "3": //Load
                    if (isSaved == false)
                    { 
                        Console.WriteLine("Do you want to save your current journal before loading a new one (y/n)");
                        string saveResponse = Console.ReadLine();
                        if (saveResponse.ToUpper() == "Y")
                        {
                            myJournal.SaveToFile(PromptFileName("save"));
                        }
                    }

                    myJournal.LoadFromFile(PromptFileName("load"));
                    isSaved = true;
                    break;
                case "4": //Save
                    myJournal.SaveToFile(PromptFileName("save"));
                    isSaved = true;
                    break;
                case "5": //Quit
                    isFinished = true;
                    break;
                default:
                    Console.WriteLine("Please select a number from 1 - 5.");
                    break; 
            }  
        } while (isFinished == false);
    }

    static void CreateNewJournalEntry(Journal journal)
    {
        Entry journalEntry = new Entry();
        
        DateTime today = DateTime.Now;
        journalEntry._date = today.ToShortDateString();
        
        PromptGenerator prompt = new PromptGenerator();
        journalEntry._promptText = prompt.GetRandomPrompt();
        Console.WriteLine(journalEntry._promptText);

        journalEntry._entryText = Console.ReadLine();
        
        journal.AddEntry(journalEntry);
    }

    static string PromptFileName(string action)
    {
        Console.WriteLine($"What is the name of the file to {action}?");
        return Console.ReadLine();
    }
}

class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry e in _entries)
        {
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

class Entry
{
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}\n");
    }
}

class PromptGenerator
{
    public List<string> _prompts = new List<string>(); 
    
    public string GetRandomPrompt()
    {
        Random randomizer = new Random();

        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What is one goal I worked on today, or would like to work on tomorrow?");
        _prompts.Add("Describe something I did successfully today.");
        _prompts.Add("What was the most beautiful thing I saw or experienced today?");
        _prompts.Add("Describe a family interaction that happened today.");
        _prompts.Add("What is something that worried me today? What can I do to resolve it?");
        
        int randomIndex = randomizer.Next(0, _prompts.Count());
        
        return _prompts.ElementAt(randomIndex);
    }
}