// For the Exceeds Core Requirements I did the following:
// The program allows the user to choose from 2 different scriptures (one with multiple verses)
// The program asks the user how many words to hide between 1-4, and hides that number each round
// When randomly hiding words, the program will only choose from words that are not already hidden.

using System;
using System.Runtime.CompilerServices;

class Program
{
        static string _refBook = "";
        static int _refChapter = 0;
        static int _refStartVerse = 0;
        static int _refEndVerse = 0;
        static string _scriptureText = "";
    static void Main(string[] args)
    {   
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer Program!\n");
        
        ChooseScripture();
        
        Reference scriptureReference;

        // if the scripture has only 1 verse
        if (_refStartVerse == 0 || _refEndVerse == _refStartVerse)
        {
            scriptureReference = new Reference(_refBook, _refChapter, _refStartVerse);
        }
        // if the scripture has multiple verses
        else 
        {
            scriptureReference = new Reference(_refBook, _refChapter, _refStartVerse, _refEndVerse);
        }
        
        Scripture toMemorize = new Scripture(scriptureReference,_scriptureText);
        
        bool isContinuing = true;
        int numToHide = 0;

        // ask the user for number of words to hide
        while (! (numToHide > 0 && numToHide <= 4))
        {
            Console.Write("How many words would you like to hide each time? Choose between 1 - 4: ");
            string response = Console.ReadLine();
            int.TryParse(response, out numToHide);
        }

        // Begin the scripture memorizing part of the program
        do
        {
            Console.Clear();
            Console.WriteLine(toMemorize.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            
            if (Console.ReadLine().ToLower() == "quit")
            {
                isContinuing = false;
            }
            else if (toMemorize.IsCompletelyHidden())
            {
                isContinuing = false;
            }
            else
            {
                toMemorize.HideRandomWords(numToHide);
            }

        } while (isContinuing);
        
    }

    static void ChooseScripture()
    {
        Console.WriteLine("Choose one of the following:\n");
        Console.WriteLine("1. John 3:5");
        Console.WriteLine("2. Moroni 10:4-5");
        Console.Write("\nType 1 or 2: ");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            _refBook = "John";
            _refChapter = 3;
            _refStartVerse = 5;
            _scriptureText = "Jesus answered, Verily, verily, I say unto thee, Except a man be born of water and of the Spirit, he cannot enter into the kingdom of God.";
        }
        else 
        {
            _refBook = "Moroni";
            _refChapter = 10;
            _refStartVerse = 4;
            _refEndVerse = 5;
            _scriptureText = "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. \nAnd by the power of the Holy Ghost ye may know the truth of all things.";
        }
    }
}