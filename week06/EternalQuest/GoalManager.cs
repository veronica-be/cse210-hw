public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {
        _goals.Clear();
        _score = 0;

    }

    public void Start() // Main menu and process
    {
        int choice = 0;

        do
        {
            DisplayPlayerInfo();
            Console.WriteLine();

            List<int> options = new List<int>() { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("Menu Options");
            Console.WriteLine(" 1. Create New Goals");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");

            IntTryLoop intTryLoop = new IntTryLoop("Select a choice from the menu: ", options, "Must be a number in range from 1 to 6.");
            intTryLoop.Start();

            choice = intTryLoop.GetIntResponse();

            Console.Clear();


            if (choice == 1) //Create New Goals
            {
                CreateGoal(); // display sub menu and more
            }
            else if (choice == 2) //List Goals
            {
                ListGoals();
            }
            else if (choice == 3)// Save Goals
            {
                SaveGoals();
            }
            else if (choice == 4)// Load Goals
            {
                LoadGoals();
            }
            else if (choice == 5)//Record Event
            {
                RecordEvent();
            }

        } while (choice != 6);
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
    }

    private void CreateGoal()
    {
        int choice = 0;
        List<int> options = new List<int>() { 1, 2, 3 };

        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");

        IntTryLoop intTryLoop = new IntTryLoop("Which type of goal would you like to create?  ", options, "Must be a number in range from 1 to 3.");
        intTryLoop.Start();

        choice = intTryLoop.GetIntResponse();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        IntTryLoop intTryLoop1 = new IntTryLoop("What is the amount of points associated with this goal? ");
        intTryLoop1.Start();
        int points = intTryLoop1.GetIntResponse();


        if (choice == 1) // Simple Goal Option - submenu
        {
            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
            _goals.Add(simpleGoal);
        }
        else if (choice == 2) //Eternal Goal Option - submenu 
        {
            EternalGoal eternalGoal = new EternalGoal(name, description, points);
            _goals.Add(eternalGoal);
        }
        else if (choice == 3) //Checklist Goal Option - submenu 
        {
            IntTryLoop intTryLoop2 = new IntTryLoop("How many times does this goal need to be accomplished for a bonus? ");
            intTryLoop2.Start();
            int target = intTryLoop2.GetIntResponse();

            IntTryLoop intTryLoop3 = new IntTryLoop("What is the bonus for accomplishing it that many times? ");
            intTryLoop3.Start();
            int bonus = intTryLoop3.GetIntResponse();

            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(checklistGoal);
        }
    }

    private void ListGoals() // 2 option in main menu - It list all the goals of a list 
    {
        if (!_goals.Any()) //  https://stackoverflow.com/questions/24755385/which-i-should-use-any-or-count-and-which-one-is-faster-will-both-return
        {
            Console.WriteLine("There are no goals.");
        }
        else
        {
            Console.WriteLine("The goals are:");

            int counter = 1;
            foreach (var goal in _goals)
            {
                Console.Write($"    {counter}. ");

                if (goal.IsComplete() == true)
                {
                    Console.Write(@"[✓] ");
                }
                else
                {
                    Console.Write("[ ] ");
                }

                string goalDetails = goal.GetDetailsString();
                Console.Write(goalDetails + Environment.NewLine);
                counter++;
            }

        }
    }

    private List<string> ListGoalDetails() //  Make List to save similar to acsv format 
    {
        List<string> lines = new List<string>();

        foreach (var goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        return lines;
    }

    private void SaveGoals()//3      -- Making sure they show no repetition and can get updated
    {
        Console.Write("What is the filename for the goal file? ");
        string filePath = Console.ReadLine().Trim();

        string firstLine = "GoalType--|--Name--|--Description--|--Points--|--(more details depending Goal type)";
        List<string> linesGoals = ListGoalDetails(); // Converts all _goals to strings of information
        List<string> linesToSave = new List<string>();

        if (System.IO.File.Exists(filePath))
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);

            List<string> goalsNewToAdd = new List<string>(linesGoals);

            foreach (string line in lines.Skip(1))// data inside txt
            {
                string[] parts = line.Split("--|--");

                bool isNotInside = true;

                string typeGoal = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                foreach (var goal in linesGoals)
                {
                    if (goal.Contains($"{typeGoal}--|--{name}--|--{description}--|--{points}"))
                    {
                        linesToSave.Add(goal);
                        isNotInside = false;
                        goalsNewToAdd.Remove(goal);
                        break;
                    }
                }
                if (isNotInside)
                {
                    linesToSave.Add(line);
                }
            }

            linesToSave.AddRange(goalsNewToAdd);

            System.IO.File.WriteAllText(filePath, string.Empty);
            System.IO.File.AppendAllText(filePath, firstLine + Environment.NewLine);
            System.IO.File.AppendAllLines(filePath, linesToSave);
        }

        else
        {
            System.IO.File.AppendAllText(filePath, firstLine + Environment.NewLine);
            System.IO.File.AppendAllLines(filePath, linesGoals);
        }
    }

    private void LoadGoals() //4 -- Instead of setting the score it calculates it
    {
        Console.Write("What is the filename for the goal file? ");
        string filePath = Console.ReadLine();

        try
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string line in lines.Skip(1))
            {
                string[] parts = line.Split("--|--");

                string typeGoal = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                if (typeGoal == "SimpleGoal")
                {
                    SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                    bool isComplete = bool.Parse(parts[4]);

                    if (isComplete)
                    {
                        simpleGoal.RecordEvent();
                        _score += points;
                    }

                    _goals.Add(simpleGoal);
                }
                else if (typeGoal == "EternalGoal")
                {
                    EternalGoal eternalGoal = new EternalGoal(name, description, points);
                    int timesDone = int.Parse(parts[4]);

                    for (int i = 0; timesDone > i; i++)
                    {
                        eternalGoal.RecordEvent();
                        _score += points;
                    }

                    _goals.Add(eternalGoal);
                }
                else if (typeGoal == "ChecklistGoal")
                {
                    int amountCompleted = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);

                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);

                    for (int i = 0; amountCompleted > i; i++)
                    {
                        checklistGoal.RecordEvent();
                        _score += points;
                    }

                    _goals.Add(checklistGoal);
                }
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Sorry the file was not found.");
        }
    }

    private void RecordEvent()//5
    {
        int counter = 0;
        List<int> options = new List<int>();
        Console.WriteLine("The goals are:");

        foreach (var item in _goals)
        {
            counter++;
            Console.WriteLine($" {counter}. {item.GetName()}");
            options.Add(counter);
        }

        IntTryLoop intTryLoop = new IntTryLoop("Which goal have you accomplish? ", options, $"It must be from 1 to {_goals.Count}");
        intTryLoop.Start();
        int index = intTryLoop.GetIntResponse() - 1;
        if (_goals[index].IsComplete())
        {
            Console.WriteLine("Horray!!! This goal is already done. Achive the next one.");
        }
        else
        {
            _goals[index].RecordEvent();
            int pointsObtained = _goals[index].GetPoints();
            _score += pointsObtained;
            Console.WriteLine($"Congratulations! You have earned {pointsObtained} points!");
            Console.WriteLine($"You now have {_score} points.");
        }


    }
}