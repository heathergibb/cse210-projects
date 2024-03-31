using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    public GoalManager()
    {
        _score = 0;
    }
    public void Start()
    {
        // The main function of the class. Runs the menu loop

        bool continueProgram = true;

        // loop until the user chooses "6" to quit
        while (continueProgram)
        {
            DisplayPlayerInfo();

            // Display Menu
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            bool entryError;
            do
            {
                entryError = false;
                string userChoice = Console.ReadLine();
                                
                switch (userChoice)
                {
                    case "1": // Create new goal
                        CreateGoal();
                        break;
                    case "2": // List goals
                        ListGoalDetails();
                        break;
                    case "3": // Save goals
                        SaveGoals();
                        break;
                    case "4": // Load goals
                        LoadGoals();
                        break;
                    case "5": // Record Event
                        RecordEvent();
                        break;
                    case "6": // Quit
                        continueProgram = false;
                        break;
                    default: // invalid choice - reloop until valid choice entered
                        Console.WriteLine("Error - Please enter a valid choice (1 - 6): ");
                        entryError = true;
                        break;
                }

            } while (entryError);

            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        // Displays the players current score\
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        // Lists the names of each of the goals
        int numCount = 0;
        foreach (Goal g in _goals)
        {
            numCount++;
            Console.WriteLine($"{numCount}. {g.GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        // Lists the details of each goal (checkbox)
        Console.WriteLine("\nThe goals are: ");
        int i = 0;
        foreach(Goal g in _goals)
        {
            i++;
            Console.WriteLine($"{i}. {g.GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        // Asks the user for the info about the new goal, create it and adds to list
        Console.WriteLine("\nThe types of goals are: ");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalChoice = Console.ReadLine();

        while (!(goalChoice == "1" || goalChoice == "2" || goalChoice == "3"))
        {
            Console.Write("Invalid Selection. Choose 1 - 3: ");
            goalChoice = Console.ReadLine();
        }

        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        
        Console.Write("What is a short description of your goal? ");
        string goalDesc = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        string goalPoints = Console.ReadLine();

        if (goalChoice == "1")
        {
            SimpleGoal newGoal = new SimpleGoal(goalName, goalDesc, goalPoints);
            _goals.Add(newGoal);
        }
        else if (goalChoice == "2")
        {
            EternalGoal newGoal = new EternalGoal(goalName, goalDesc, goalPoints);
            _goals.Add(newGoal);
        }
        else if (goalChoice == "3")
        {
            string response;
            bool validResponse;
            int target;
            int bonusPoints;

            do
            {
                Console.Write("How many times do you need to complete this goal to get awarded bonus points? ");
                response = Console.ReadLine();
                validResponse = int.TryParse(response, out target);

                if (validResponse == false)
                { 
                    Console.WriteLine("Invalid response. Enter a valid interger.");
                }
            } while (validResponse == false);
            
            do
            {
                Console.Write("How many points is the bonus worth? ");
                response = Console.ReadLine();
                validResponse = int.TryParse(response, out bonusPoints);
                
                if (validResponse == false)
                { 
                    Console.WriteLine("Invalid response. Enter a valid interger.");
                }
            } while (validResponse == false);
            
            ChecklistGoal newGoal = new ChecklistGoal(goalName, goalDesc, goalPoints, target, bonusPoints);
            _goals.Add(newGoal);
        }
        else
        {
            Console.WriteLine("Error!!\n");
        }
    }

    public void RecordEvent()
    {
        // Asks user which goal they have done 
        // and records it by calling the RecordEvent method for that goal
        if (_goals.Count() > 0)
        {
            Console.WriteLine("\nThe goals are:");
            ListGoalNames();
            Console.Write("Which goal did you accomplish? ");
            string userChoice = Console.ReadLine();
            bool isValid = int.TryParse(userChoice,out int numChoice);

            while ((isValid == false) || numChoice < 1 || numChoice > _goals.Count())
            {
                Console.Write("Invalid choice. Please type a number from the list: ");
                userChoice = Console.ReadLine();
                isValid = int.TryParse(userChoice, out numChoice);
            }

            int prevScore = _score;
            int addPoints = _goals[numChoice - 1].RecordEvent();
            _score += addPoints; 

            if (prevScore / 1000 < _score / 1000)
            {   
                ThousandPointsGraphic(_score / 1000);
            }

            Console.WriteLine($"\nCongratulations! You earned {addPoints} points!");
        }
        else
        {
            Console.WriteLine("\nThere are no goals to record.");
        }
    }

    public void SaveGoals()
    {
        // Saves the list of goals to a file
        Console.Write("What is the filename to save to? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        // Loads the list of goals from the file
        Console.Write("What is the filename for your goal file? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);

        _goals.Clear();
        _score = int.Parse(lines[0]); // the first line of data contains the score

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string goalType = parts[0];
            string name;
            string desc;
            string points;

            switch (goalType)
            {
                case "SimpleGoal":
                    name = parts[1];
                    desc = parts[2];
                    points = parts[3];
                    SimpleGoal sGoal = new SimpleGoal(name, desc, points);
                    if (parts[4] == "True")
                    {
                        sGoal.RecordEvent();
                    }
                    _goals.Add(sGoal);
                    break;
                case "EternalGoal":
                    name = parts[1];
                    desc = parts[2];
                    points = parts[3];
                    EternalGoal eGoal = new EternalGoal(name, desc, points);
                    _goals.Add(eGoal);
                    break;
                case "ChecklistGoal":
                    name = parts[1];
                    desc = parts[2];
                    points = parts[3];
                    int target = int.Parse(parts[4]); 
                    int bonusPoints = int.Parse(parts[5]);
                    int amtComplete = int.Parse(parts[6]);
            
                    ChecklistGoal cGoal = new ChecklistGoal(name, desc, points, target, bonusPoints);
                    
                    for (int i = 1; i <= amtComplete; i++)
                    {
                        cGoal.RecordEvent();
                    }
                    _goals.Add(cGoal);
                    break;
                default:
                    break;
            }
        }
    }

    public void ThousandPointsGraphic(int numK)
    {
        Console.Clear();

        if (numK == 1)
        {
            Console.WriteLine();
            Console.WriteLine("****************************************************");
            Console.WriteLine("****************************************************");
            Console.WriteLine("**                                                **");
            Console.WriteLine("**     **     *******     *******     *******     **");
            Console.WriteLine("**     **     **   **     **   **     **   **     **");
            Console.WriteLine("**     **     **   **     **   **     **   **     **");
            Console.WriteLine("**     **     **   **     **   **     **   **     **");
            Console.WriteLine("**     **     **   **     **   **     **   **     **");
            Console.WriteLine("**     **     **   **     **   **     **   **     **");
            Console.WriteLine("**     **     *******     *******     *******     **");
            Console.WriteLine("**                                                **");
            Console.WriteLine("****************************************************");
            Console.WriteLine("****************************************************");
        }
        else if (numK == 2)
        {
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("**                                                     **");
            Console.WriteLine("**     *******     *******     *******     *******     **");
            Console.WriteLine("**          **     **   **     **   **     **   **     **");
            Console.WriteLine("**         **      **   **     **   **     **   **     **");
            Console.WriteLine("**        **       **   **     **   **     **   **     **");
            Console.WriteLine("**      **         **   **     **   **     **   **     **");
            Console.WriteLine("**     **          **   **     **   **     **   **     **");
            Console.WriteLine("**     *******     *******     *******     *******     **");
            Console.WriteLine("**                                                     **");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");
        }
        else if (numK == 3)
        {
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("**                                                     **");
            Console.WriteLine("**     *******     *******     *******     *******     **");
            Console.WriteLine("**          **     **   **     **   **     **   **     **");
            Console.WriteLine("**          **     **   **     **   **     **   **     **");
            Console.WriteLine("**     *******     **   **     **   **     **   **     **");
            Console.WriteLine("**          **     **   **     **   **     **   **     **");
            Console.WriteLine("**          **     **   **     **   **     **   **     **");
            Console.WriteLine("**     *******     *******     *******     *******     **");
            Console.WriteLine("**                                                     **");
            Console.WriteLine("**********************************************************");
            Console.WriteLine("**********************************************************");
        }
        else if (numK == 4)
        {
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("**                                                     **");
            Console.WriteLine("**     **   **     *******     *******     *******     **");
            Console.WriteLine("**     **   **     **   **     **   **     **   **     **");
            Console.WriteLine("**     **   **     **   **     **   **     **   **     **");
            Console.WriteLine("**     *******     **   **     **   **     **   **     **");
            Console.WriteLine("**          **     **   **     **   **     **   **     **");
            Console.WriteLine("**          **     **   **     **   **     **   **     **");
            Console.WriteLine("**          **     *******     *******     *******     **");
            Console.WriteLine("**                                                     **");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");
        }
        else if (numK == 5)
        {
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("**                                                     **");
            Console.WriteLine("**     *******     *******     *******     *******     **");
            Console.WriteLine("**     **          **   **     **   **     **   **     **");
            Console.WriteLine("**     **          **   **     **   **     **   **     **");
            Console.WriteLine("**     *******     **   **     **   **     **   **     **");
            Console.WriteLine("**          **     **   **     **   **     **   **     **");
            Console.WriteLine("**          **     **   **     **   **     **   **     **");
            Console.WriteLine("**     *******     *******     *******     *******     **");
            Console.WriteLine("**                                                     **");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("**                                                 **");
            Console.WriteLine("**     **      **        ***        **      **     **");
            Console.WriteLine("**      **    **        ** **        **    **      **");
            Console.WriteLine("**       **  **        **   **        **  **       **");
            Console.WriteLine("**        ****         *******         ****        **");
            Console.WriteLine("**         **         *********         **         **");
            Console.WriteLine("**         **         **     **         **         **");
            Console.WriteLine("**         **         **     **         **         **");
            Console.WriteLine("**         **         **     **         **         **");
            Console.WriteLine("**                                                 **");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
        }
                
        Thread.Sleep(1000); 
    }    
}