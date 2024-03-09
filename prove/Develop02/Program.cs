using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        
        Journal myJournal = new Journal();
        
        bool isFinished = false; //use to exit loop when finished
        bool isSaved = true; // is the current journal saved or null
        string userResponse = "";
        
        do 
        {
            Console.WriteLine("\nPlease select one of the following choices:");
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
                        Console.WriteLine($"\nYou have unsaved changes in your current journal. Do you want to save your current journal first? (y/n)");
                        string saveResponse = Console.ReadLine();
                        
                        if (saveResponse.ToUpper() == "Y")
                        { 
                            myJournal.SaveToFile(PromptSaveFileName(myJournal._currentFileName));
                            isSaved = true;
                        }
                    }

                    myJournal._currentFileName = PromptLoadFileName();
                    myJournal.LoadFromFile(myJournal._currentFileName);
                    isSaved = true;
                    break;
                case "4": //Save
                    if (myJournal._entries.Count() == 0)
                    {   
                        Console.WriteLine("\nThere are no entries to save. Write and entry first, then save.");
                    }
                    else 
                    {
                        myJournal._currentFileName = PromptSaveFileName(myJournal._currentFileName);
                        myJournal.SaveToFile(myJournal._currentFileName);
                        isSaved = true;
                    }
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
        
        Console.WriteLine();
        Console.WriteLine(journalEntry._promptText);
        Console.Write("> ");

        journalEntry._entryText = Console.ReadLine();
        
        journal.AddEntry(journalEntry);
    }

    static string PromptSaveFileName(string fileName)
    {
        // if the file has already been created, ask if the user would like to 
        // save to the existing file.               
        if (fileName != "")
        {
            Console.WriteLine($"\nDo you want to save as {fileName}? (y/n) ");
            
            // if the user does not want to save to the existing file, 
            // change the fileName variable to "" and later in this function
            // there will be a prompt for a new fileName
            if (Console.ReadLine().ToUpper() == "N")
            {
                fileName = "";
            }
        }
        
        if (fileName == "")
        {
            Console.WriteLine("What is the save name for the file? ");
            fileName = Console.ReadLine();
        }

        return fileName;
    }

    static string PromptLoadFileName()
    { 
        Console.WriteLine("\nWhat is the name of the file to load? ");
        return Console.ReadLine();
    }
}