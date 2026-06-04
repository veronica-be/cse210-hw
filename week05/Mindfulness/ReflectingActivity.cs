public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<int> _promptsAlreadyDisplayed = new List<int>();
    private List<int> _questionsAlreadyDisplayed = new List<int>();
    private Random _random = new Random();




    public ReflectingActivity(string name, string description, List<string> prompts, List<string> questions) : base(name, description)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();

        Console.Clear();

        DisplayQuestions();

        Console.WriteLine();

        DisplayEndingMessage();

    }

    private string GetRandomPrompt()
    {
        int total = _prompts.Count();

        if (total == 0)
        {
            return "The list of prompts is empty";
        }

        if (_promptsAlreadyDisplayed.Count() >= total)
        {
            _promptsAlreadyDisplayed.Clear();
        }

        int index;

        while (true)
        {
            index = _random.Next(0, total);

            if (!_promptsAlreadyDisplayed.Contains(index))
            {
                _promptsAlreadyDisplayed.Add(index);
                break;
            }
        }

        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        int total = _questions.Count();

        if (total == 0)
        {
            return "The list of questions is empty";
        }

        if (_questionsAlreadyDisplayed.Count() >= total)
        {
            _questionsAlreadyDisplayed.Clear();
        }

        int index;

        while (true)
        {
            index = _random.Next(0, total);

            if (!_questionsAlreadyDisplayed.Contains(index))
            {
                _questionsAlreadyDisplayed.Add(index);
                break;
            }
        }

        return _questions[index];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        string prompt = GetRandomPrompt();
        Console.WriteLine($" --- {prompt} ---");
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

    }

    private void DisplayQuestions()
    {
        int times = GetDuration() / 5;
        int remainder = GetDuration() % 5;

        if (times == 0)
        {
            Console.Write($" > {GetRandomQuestion()}");
            ShowSpinner(remainder);
            return;
        }


        for (int i = 0; i < times; i++)
        {
            Console.Write($" > {GetRandomQuestion()}");

            if (remainder == 0)
            {
                ShowSpinner(5);
            }

            else
            {
                if (i == times - 1)
                {
                    ShowSpinner(5 + remainder);
                }
                else
                {
                    ShowSpinner(5);
                }
            }

        }

    }
}