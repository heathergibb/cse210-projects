using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

class Activity
{
    protected string _name;
    protected string _description;
    private string _logFileName;
    private string _logDateFormat;
    private int _duration;

    public Activity()
    {
        _name = "activity";
        _description = "";
        _logFileName = "mindfulness_log.txt";
        _logDateFormat = "yyyy'-'MM'-'dd' 'HH':'mm";
        _duration = 0;
    }
    public int GetDuration()
    {
        return _duration;
    }
    public string GetFileName()
    {
        return _logFileName;
    }
    public string GetLogDateFormat()
    {
        return _logDateFormat;
    }

    public void SetFileName(string fileName)
    {
        _logFileName = fileName;
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        
        bool isValid = false;
        do
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string response = Console.ReadLine();
            isValid = int.TryParse(response, out _duration);
            
            if (isValid == false)
            {
                Console.WriteLine("Please enter a valid number.");
            }
        } while (isValid == false);       
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!\n");
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinCharacters = new List<string>() {"/","-","\\","|","/","-","\\","|"};
        int i = 0; 
        int sleepTime = 400;

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinCharacters[i]);
            Thread.Sleep(sleepTime);
            Console.Write("\b \b");

            i++; // increment to the next spinner charater in the list
            
            // if the list of spinner characters has been run through, start again at 0
            if (i >= spinCharacters.Count())
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        string clearLine = "\b \b";

        for (int i = seconds; i > 0; i--)
        {
            if (seconds > 99)
            {
                seconds = 99; //don't allow countdown to be greater than 99
                clearLine = "\b\b  \b\b";
            }
            else if (seconds > 9)
            {
                clearLine = "\b\b  \b\b";
            }
            else
            {
                clearLine = "\b \b";
            }

            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write(clearLine);
        }
    }

    public void SaveLogFile(string logDetails)
    {
        using (StreamWriter outputFile = new FileInfo(_logFileName).AppendText())
        {
            outputFile.WriteLine($"{logDetails}");
        }
    }
}