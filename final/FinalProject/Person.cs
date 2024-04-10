using System.Configuration.Assemblies;

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
    private bool _changed;
    private string _fileName;

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
        _endowment = new Ordinance("Endowment");
        _sealingSpouse = new SealingSpouse("Sealing to Spouse");
        _sealingParents = new SealingParents("Sealing to Parents");
        _sources.Clear();

        _changed = false;
        _fileName = "";
    }

    public string GetPersonName()
    {
        return $"{_givenName} {_lastName}";
    }

    public string GetFileName()
    {
        return _fileName;
    }

    public void SetFileName(string fileName)
    {
        _fileName = fileName;
    }

    public void SetBirth(BirthEvent birth)
    {
        _birth = birth;
    }
    public void SetMarriage(MarriageEvent marriage)
    {
        _marriage = marriage;
    }
    public void SetDeath(DeathEvent death)
    {
        _death = death;
    }
    public void SetBaptism(Ordinance ord)
    {
        _baptism = ord;
    }
    public void SetConfirmation(Ordinance ord)
    {
        _confirmation = ord;
    }
    public void SetInitiatory(Ordinance ord)
    {
        _initiatory = ord;
    }
    public void SetEndowment(Ordinance ord)
    {
        _endowment = ord;
    }
    public void SetSealingSpouse(SealingSpouse ss)
    {
        _sealingSpouse = ss;
    }
    public void SetSealingParents(SealingParents sp)
    {
        _sealingParents = sp;
    }
    public void SetSources(List<Source> sources)
    {
        _sources = sources;
    }
    public void SetChanged(bool changed)
    {
        _changed = changed;
    }
    public bool GetChanged()
    {
        return _changed;
    }
    public void DisplayOrdinanceMenu()
    {
        // displays each ordinance with the details formatted according to 
        // their specific type
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
        _changed = true;

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
                case "Sealing to Spouse":
                    Console.Write("What is the spouse's name: ");
                    string spouse = Console.ReadLine();

                    _sealingSpouse = new SealingSpouse(true, date, location, type, spouse);
                    break;
                case "Sealing to Parents":
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
        // displays the menu options and for the events, calls the event class to
        // handle the formatting of the display string, according to each type.
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
        // display all previous sources then handles entry of new source information
        Console.Clear();
        Console.WriteLine($"Sources for {GetPersonName()}");
        Console.WriteLine();
        DisplaySourceList();

        Console.WriteLine("-------------------");
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
            _changed = true;
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
        Console.WriteLine($"FULL DETAILS FOR {_givenName.ToUpper()} {_lastName.ToUpper()}");
        Console.WriteLine();
        Console.WriteLine("VITALS");
        Console.WriteLine("");
        Console.WriteLine($"Sex : {_sex}");
        Console.WriteLine($"Birth: {_birth.DisplayEventString()}");
        Console.WriteLine($"Marriage: {_marriage.DisplayEventString()}");
        Console.WriteLine($"Death: {_death.DisplayEventString()}");
        Console.WriteLine();
        Console.WriteLine($"ORDINANCES");
        Console.WriteLine("");
        Console.WriteLine($"Baptism: {_baptism.DisplayOrdinanceString()}");
        Console.WriteLine($"Confirmation: {_confirmation.DisplayOrdinanceString()}");
        Console.WriteLine($"Initiatory: {_initiatory.DisplayOrdinanceString()}");
        Console.WriteLine($"Endowment: {_endowment.DisplayOrdinanceString()}");
        Console.WriteLine($"Sealing to Spouse: {_sealingSpouse.DisplayOrdinanceString()}");
        Console.WriteLine($"Sealing to Parents: {_sealingParents.DisplayOrdinanceString()}");
        Console.WriteLine("");
        Console.WriteLine($"{_sources.Count()} SOURCES");
        Console.WriteLine();
        foreach (Source s in _sources)
        {
            Console.WriteLine(s.FormatListDisplay());
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void DisplayTempleCardDetails()
    {
        Console.Clear();
        Console.WriteLine("Temple Card");
        Console.WriteLine();
        Console.WriteLine(GetPersonName());
        Console.WriteLine();
        Console.WriteLine($"Baptism: {_baptism.DisplayOrdinanceString()}");
        Console.WriteLine($"Confirmation: {_confirmation.DisplayOrdinanceString()}");
        Console.WriteLine($"Initiatory: {_initiatory.DisplayOrdinanceString()}");
        Console.WriteLine($"Endowment: {_endowment.DisplayOrdinanceString()}");
        Console.WriteLine($"Sealing to Spouse: {_sealingSpouse.DisplayOrdinanceString()}");
        Console.WriteLine($"Sealing to Parents: {_sealingParents.DisplayOrdinanceString()}");
        Console.WriteLine();
        Console.WriteLine($"Printed: {DateTime.Now.ToString("dd MMMM yyyy hh:mm")}");
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void SaveData()
    {
        // save all the person information to a .txt file
        FileManager save =  new FileManager();

        if (_fileName == "")
        {
            _fileName = save.ValidateSaveName($"{_givenName}{_lastName}");
        }

        //create list of strings of data to save to txt file
        List<string> saveData = new List<string>();

        saveData.Add($"{_fileName}|{_givenName}|{_lastName}|{_sex}");
        // Events
        saveData.Add(_birth.FormatSaveString());
        saveData.Add(_marriage.FormatSaveString());
        saveData.Add(_death.FormatSaveString());

        // Ordinances
        saveData.Add(_baptism.FormatSaveString());
        saveData.Add(_confirmation.FormatSaveString());
        saveData.Add(_initiatory.FormatSaveString());
        saveData.Add(_endowment.FormatSaveString());
        saveData.Add(_sealingSpouse.FormatSaveString());
        saveData.Add(_sealingParents.FormatSaveString());

        // Sources
        foreach (Source s in _sources)
        {
            saveData.Add(s.FormatSaveString());
        }

        save.SavePerson(_fileName,saveData);
        _changed = false;
    }
}