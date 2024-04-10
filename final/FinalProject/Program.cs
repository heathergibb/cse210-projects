//refer to the readme.txt file for details about this program and how it is intended to work

class Program
{    static void Main(string[] args)
    {
        MenuManager runManager = new MenuManager();

        bool loopAgain = true;

        // the program will keep returning to and running this menu until the 
        // user chooses Quit.
        while (loopAgain)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Ancestor Tracker");
            Console.WriteLine();
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
                    string[] fileNames = runFileManager.GetFileNames();
                    
                    // if no files exist in the save folder, display a message and stay 
                    // in the main menu until the user either creates a new person or quits
                    if (fileNames.Count() > 0)
                    {
                        string path = runManager.LoadFromFileMenu(fileNames);
                        if (path != "")
                        {
                            runManager = new MenuManager(runFileManager.LoadPerson(path));
                            runManager.PersonMenu();
                        }
                    } 
                    else
                    {
                        Console.WriteLine("There are no files to load. Press Enter to continue...");
                        Console.ReadLine();
                    }  
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