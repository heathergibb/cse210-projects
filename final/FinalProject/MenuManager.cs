public class MenuManager
{
    private Person _person;

    public MenuManager()
    {

    }

    public MenuManager(Person person)
    {
        _person = person;
    }

    public string LoadFromFileMenu(string[] fileNames)
    {
        // given a list of file names that were found in the FileManager method
        // create the list with the options and handle the user selection
        // returns the selected filename

        Console.Clear();
        Console.WriteLine("Load Person From File:");
        Console.WriteLine();
        
        int i = 1;

        foreach (string f in fileNames)
        {
            string[] lines = System.IO.File.ReadAllLines(f);
            string[] parts = lines[0].Split("|");

            Console.WriteLine($"{i}. {parts[0]}.txt - {parts[1]} {parts[2]} {parts[3]}");
            i++;
        }

        Console.WriteLine($"{i}. Go back");
        Console.Write("Select an option from the list: ");
        
        int selected;
        bool error;

        do
        {
            error = false;
            
            if (int.TryParse(Console.ReadLine(),out selected))
            {
                if  (!(selected > 0 && selected <= i))
                {
                    error = true;
                }
            }
            else
            {
                error = true;
            }

            if (error)
            {
                Console.WriteLine($"Invalid entry. Select a number between 1 - {i}");
            }
        } while (error);
        
        if (selected == i)
        {
            return "";
        }
        else    
        {
            return fileNames[selected - 1];
        }

    }
    public void PersonMenu()
    {
        // displays the person menu options and handles the user's response.
        // calls the appropriate functions and returns to this menu until the 
        // user chooses to Return to Main Menu

        bool loopAgain = true;

        while (loopAgain)
        {
            Console.Clear();
            Console.WriteLine($"Details for {_person.GetPersonName()}:");
            Console.WriteLine();
            Console.WriteLine("1. Ordinances");
            Console.WriteLine("2. Events/Vitals");
            Console.WriteLine("3. Submit Source");
            Console.WriteLine("4. Display Full Details");
            Console.WriteLine("5. Display Temple Card Details");
            Console.WriteLine("6. Save to File");
            Console.WriteLine("7. Return to Main Menu");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    // List ordinances and if they are complete
                    // Allow user to select and edit
                    OrdinanceMenu();
                    break;
                case "2":
                    // list vitals
                    // Allow user to select and edit
                    VitalsEventsMenu();
                    break;
                case "3":
                    // Display source list before prompting user for new source details
                    _person.SubmitSource();
                    break;
                case "4":
                    // Display a formatted preview of all the details
                    // including vitals/events, ordinances, and sources
                    _person.DisplayFullDetails();
                    break;
                case "5":
                    // Display ordinance details similar to a temple card
                    _person.DisplayTempleCardDetails();
                    break;
                case "6":
                    // Save all the details to a file
                    _person.SaveData();
                    break;
                case "7":
                    // exit loop return to main menu

                    if (_person.GetChanged()) //changes were made, prompt to save first
                    {
                        Console.Write("Would you like to save changes before returning to Main Menu (Y, N)? ");
                        string answer = Console.ReadLine();

                        while (!(answer.ToUpper() == "Y" || answer.ToUpper() == "N"))
                        {
                            Console.Write("Invalid entry. Enter Y or N: ");
                            answer = Console.ReadLine();
                        }

                        if (answer.ToUpper() == "Y") // save changes
                        {
                            _person.SaveData();
                        }
                    }
                    loopAgain = false;
                    break;
                default:
                    InvalidSelection();
                    break;
            }   
        }
    }

    public void OrdinanceMenu()
    {
        // displays the ordinances in a menu by calling a function in the Person class.
        // Handles the user's selection of which ones to add/edit. 
        // Keep looping through this menu until the user chooses to exit

        bool loopAgain = true;

        while (loopAgain)
        {
            Console.Clear();
            Console.WriteLine($"Ordinance Information for {_person.GetPersonName()}");
            Console.WriteLine();

            _person.DisplayOrdinanceMenu();

            switch (Console.ReadLine())
            {
                case "1": //Baptism
                    _person.EditOrdinance("Baptism");
                    break;
                case "2": //Confirmation
                    _person.EditOrdinance("Confirmation");
                    break;
                case "3": //Initiatory
                    _person.EditOrdinance("Initiatory");
                    break;
                case "4": //Endowment
                    _person.EditOrdinance("Endowment");
                    break;
                case "5": //SealingSpouse
                    _person.EditOrdinance("Sealing to Spouse");
                    break;
                case "6": //SealingParents
                    _person.EditOrdinance("Sealing to Parents");
                    break;
                case "7": //Exit
                    loopAgain = false;
                    break;
                default:
                    InvalidSelection();
                    break;
            }
        }                
    }

    public void VitalsEventsMenu()
    {
        // displays the vitals and events in a menu by calling a function in the Person class.
        // Handles the user's selection of which ones to add/edit. 
        // Keep looping through this menu until the user chooses to exit
        bool loopAgain = true;

        while (loopAgain)
        {
            Console.Clear();
            Console.WriteLine($"Vitals and Events for {_person.GetPersonName()}");
            Console.WriteLine();

            _person.DisplayVitalsEventsMenu();

            switch (Console.ReadLine())
            {
                case "1": // given name
                    Console.Write("Enter given name: ");
                    _person.SetGivenName(Console.ReadLine());
                    _person.SetChanged(true);
                    break;
                case "2": // last name
                    Console.Write("Enter last name: ");
                    _person.SetLastName(Console.ReadLine());
                    _person.SetChanged(true);
                    break;
                case "3": // sex
                    _person.SetSex(EnterSexInput());
                    _person.SetChanged(true);
                    break;
                case "4": // birth
                    _person.EnterBirthInput();
                    _person.SetChanged(true);
                    break;
                case "5": // marriage
                    _person.EnterMarriageInput();
                    _person.SetChanged(true);
                    break;
                case "6": // death
                    _person.EnterDeathInput();
                    _person.SetChanged(true);
                    break;
                case "7": // exit
                    loopAgain = false;
                    break;
                default:
                    InvalidSelection();
                    break;
            }
        }
    }
    public void CreateNewPerson()
    {
        Console.Clear();

        Console.WriteLine("NEW PERSON ENTRY");
        Console.WriteLine("If not applicable or unknown, leave blank and press Enter to move to the next entry.");
        Console.WriteLine();
        
        Console.Write("Enter given name: ");
        string givenName = Console.ReadLine();
        
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
        
        string sex = EnterSexInput();
        
        _person = new Person(givenName, lastName, sex);

        _person.EnterBirthInput();
        _person.EnterMarriageInput();
        _person.EnterDeathInput();
    }

    public string EnterSexInput() // make sure the input is either "M" or "F" only
    {
        Console.Write("Enter sex (M or F): ");
        string sex = Console.ReadLine();
        sex = sex.ToUpper();
        while (!(sex == "M" || sex == "F"))
        {
            Console.Write("Invalid entry. Enter M or F: ");
            sex = Console.ReadLine();
            sex = sex.ToUpper();
        }

        return sex;
    }
    public void InvalidSelection()
    {
        Console.WriteLine("Invalid selection. Press Enter to continue...");
        Console.ReadLine();
    }
    
}