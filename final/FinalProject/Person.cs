public class Person
{
    private string _givenName;
    private string _lastName;
    private string _sex;
    private BirthEvent _birth;
    private MarriageEvent _marriage;
    private DeathEvent _death;
    private Ordinance _baptism;
    private Ordinance _confirmation;
    private Ordinance _initiatory;
    private Ordinance _endowment;
    private SealingSpouse _sealingSpouse;
    private SealingParents _sealingParents;
    private List<Source> _sources = new List<Source>();

    public Person(string givenName, string lastName, string sex)
    {
        _givenName = givenName;
        _lastName = lastName;
        _sex = sex;

        _birth = new BirthEvent("No Birth Details","","");
        _marriage = new MarriageEvent("No Marriage Details","","");
        _death = new DeathEvent("No Death Details","","","");

        _baptism = new Ordinance("Baptism");
        _confirmation = new Ordinance("Confirmation");
        _initiatory = new Ordinance("Initiatory");
        _endowment = new Ordinance("Endowement");
        _sealingSpouse = new SealingSpouse("Sealing to Spouse");
        _sealingParents = new SealingParents("Sealing to Parents");
        _sources.Clear();
    }

    public string GetPersonName()
    {
        return $"{_givenName} {_lastName}";
    }

    public void DisplayOrdinanceMenu()
    {
        Console.WriteLine($"1. {_baptism.DisplayOrdinanceString()}");
        Console.WriteLine($"2. {_confirmation.DisplayOrdinanceString()}");
        Console.WriteLine($"3. {_initiatory.DisplayOrdinanceString()}");
        Console.WriteLine($"4. {_endowment.DisplayOrdinanceString()}");
        Console.WriteLine($"5. {_sealingSpouse.DisplayOrdinanceString()}");
        Console.WriteLine($"6. {_sealingParents.DisplayOrdinanceString()}");
        Console.WriteLine("7. Go back");
        Console.Write("Select an ordinance to add/edit: ");  
    }

    public void EditOrdinance(string type)
    {
        Console.Write($"Has the {type} been completed? Y or N: ");
        string answer = Console.ReadLine();

        while (!(answer.ToUpper() == "Y" || answer.ToUpper() == "N"))
        {
            Console.Write("Invalid entry. Enter Y or N: ");
            answer = Console.ReadLine();
        }

        if (answer.ToUpper() == "Y") // the ordiance has been completed
        {
            Console.Write($"Enter the {type} date: ");
            string date = Console.ReadLine();

            Console.Write("Enter the location or temple: ");
            string location = Console.ReadLine();

            switch (type)
            {
                case "Baptism":
                    _baptism = new Ordinance(true, date, location, type);
                    break;
                case "Confirmation":
                    _confirmation = new Ordinance(true, date, location, type);
                    break;
                case "Initiatory":
                    _initiatory = new Ordinance(true, date, location, type);
                    break;
                case "Endowment":
                    _endowment = new Ordinance(true, date, location, type);
                    break;
                case "SealingSpouse":
                    Console.Write("What is the spouse's name: ");
                    string spouse = Console.ReadLine();

                    _sealingSpouse = new SealingSpouse(true, date, location, type, spouse);
                    break;
                case "SealingParents":
                    Console.Write("What is the father's name? ");
                    string father = Console.ReadLine();
                    Console.Write("What is the mother's name? ");
                    string mother = Console.ReadLine();

                    _sealingParents = new SealingParents(true, date, location, type, father, mother);
                    break;
                default: //this error should not be executed, it should be handled beforehand
                    Console.WriteLine("Error");
                    break;
            }
        }
        else // ordinance has not been completed
        {
            switch (type)
            {
                case "Baptism":
                    _baptism = new Ordinance(type);
                    break;
                case "Confirmation":
                    _confirmation = new Ordinance(type);
                    break;
                case "Initiatory":
                    _initiatory = new Ordinance(type);
                    break;
                case "Endowment":
                    _endowment = new Ordinance(type);
                    break;
                case "SealingSpouse":
                    _sealingSpouse = new SealingSpouse(type);
                    break;
                case "SealingParents":
                    _sealingParents = new SealingParents(type);
                    break;
                default: // error should not be executed, should be handled beforehand
                    Console.WriteLine("Error");
                    break;
            }
        }
    }

    public void DisplayVitalsEventsMenu()
    {
        Console.WriteLine($"1. Given Name - {_givenName}");
        Console.WriteLine($"2. Last Name - {_lastName}");
        Console.WriteLine($"3. Sex - {_sex}");
        Console.WriteLine($"4. Birth - {_birth.DisplayEventString()}");
        Console.WriteLine($"5. Marriage - {_marriage.DisplayEventString()}");
        Console.WriteLine($"6. Death - {_death.DisplayEventString()}");
        Console.WriteLine("7. Go back");
        Console.Write("Select an item to edit: ");  
    }
    public void SetGivenName(string name)
    {
        _givenName = name;
    }
    public void SetLastName(string name)
    {
        _lastName = name;
    }
    public void SetSex(string sex)
    {
        _sex = sex;
    }
    public void EnterBirthInput()
    {
        Console.Write("Enter birth date: ");
        string birthdate = Console.ReadLine();

        Console.Write("Enter birth location: ");
        string location = Console.ReadLine();

        Console.Write("Enter christening date: ");
        string christening = Console.ReadLine();

        _birth = new BirthEvent(birthdate, location, christening);
    }

    public void EnterMarriageInput()
    {
        Console.Write("Enter marriage date: ");
        string date = Console.ReadLine();

        Console.Write("Enter marriage location: ");
        string location = Console.ReadLine();

        Console.Write("Enter spouse: ");
        string spouse = Console.ReadLine();

        _marriage = new MarriageEvent(date, location, spouse);
    }

    public void EnterDeathInput()
    {
        Console.Write("Enter death date: ");
        string date = Console.ReadLine();

        Console.Write("Enter death location: ");
        string location = Console.ReadLine();

        Console.Write("Enter burial date: ");
        string burialDate = Console.ReadLine();

        Console.Write("Enter burial location: ");
        string burialLocation = Console.ReadLine();

        _death = new DeathEvent(date, location, burialDate, burialLocation);
    }

    public void SubmitSource()
    {
        Console.Clear();
        Console.WriteLine($"Sources for {GetPersonName()}");
        Console.WriteLine();
        DisplaySourceList();

        Console.WriteLine("Enter New Source");
        Console.WriteLine();
        Console.Write("Source Description: ");
        string desc = Console.ReadLine();
        Console.Write("Date or Date Range: ");
        string date = Console.ReadLine();
        Console.Write ("Location: ");
        string location = Console.ReadLine();
        Console.Write ("Submitted By: ");
        string submittedBy = Console.ReadLine();
        
        if (!(desc == "" && date == "" && location == "" && submittedBy == ""))
        {
            Source newSource = new Source(desc, date, location, submittedBy);
            _sources.Add(newSource);
        
            Console.WriteLine("Source successfully added. Press enter to continue...");
        }
        else
        {
            Console.WriteLine("No source added. Press enter to continue...");
        }

        Console.ReadLine();
    }
    public void DisplaySourceList()
    {
        foreach (Source s in _sources)
        {
            Console.WriteLine(s.FormatListDisplay());
        }
    }

    public void DisplayFullDetails()
    {
        Console.Clear();
        Console.WriteLine("Full details");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void DisplayTempleCardDetails()
    {
        Console.Clear();
        Console.WriteLine("Temple Card details");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}