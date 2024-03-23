class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Consider the following prompt:");
        DisplayPrompt();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();
        
        DisplayQuestions();
        DisplayEndingMessage();
        
        SaveLogFile($"{DateTime.Now.ToString(GetLogDateFormat())}: {_name} - {GetDuration()} seconds");
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count())];
            
        return prompt;
    }


    public string GetRandomQuestion()
    {
        Random rand = new Random();

        return _questions[rand.Next(_questions.Count())];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
    }

    public void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        //ask random questions for the approx. duration of seconds chosen
        while (DateTime.Now < endTime)
        {
            //end if less than 10 seconds remain, shorten the pause after the question
            double diffSeconds = endTime.Subtract(DateTime.Now).TotalSeconds;
            if (diffSeconds >= 10)
            {
                Console.Write($"> {GetRandomQuestion()} ");
                ShowSpinner(10);
            }
            else 
            {
                Console.Write($"> {GetRandomQuestion()} ");
                ShowSpinner((int)diffSeconds + 1);
            }
            Console.WriteLine();
        }
    }

}