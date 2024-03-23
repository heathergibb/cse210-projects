class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    
        _count = 0;
        _prompts = new List<string>();

        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }
    public void Run()
    {
        DisplayStartingMessage();
         
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        
        List<string> userList = new List<string>();
        
        userList = GetListFromUser();
        _count = userList.Count();

        Console.WriteLine($"You listed {_count} items!");
        
        DisplayEndingMessage();
        
        SaveLogFile($"{DateTime.Now.ToString(GetLogDateFormat())}: {_name} - {GetDuration()} seconds, listed {_count} items");
    }
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count())];

        return prompt;
    }
    public List<string> GetListFromUser()
    {
        List<string> userList = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            userList.Add(Console.ReadLine());
        }
        return userList;
    }
}