class Program
{    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Ancestor Tracker");

        MenuManager runManager = new MenuManager();

        bool loopAgain = true;

        while (loopAgain)
        {
            Console.Clear();
            
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            Console.WriteLine("1. Create New Person");
            Console.WriteLine("2. Load Person");
            Console.WriteLine("3. Quit");
            Console.Write("Select an option: ");

            string selected = Console.ReadLine();
            
            switch (selected)
            {
                case "1":
                    // create new Person object
                    runManager.CreateNewPerson();
                    runManager.PersonMenu();
                    break;
                case "2":
                    // load list of saved person files and allow user
                    // to select from the list, then load the info
                    FileManager runFileManager = new FileManager();               
                    runManager = new MenuManager(runFileManager.LoadPerson());
                    runManager.PersonMenu();
                    break;
                case "3":
                    // exit the program
                    loopAgain = false;
                    break;
                default:
                    runManager.InvalidSelection();
                    break;
            }
        }
    }
    
}