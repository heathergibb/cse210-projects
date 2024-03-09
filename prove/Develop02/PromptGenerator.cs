using System;

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