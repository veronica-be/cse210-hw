public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<int> _promptsAlreadyDisplayed = new List<int>();
    private Random _random = new Random();

    public ListingActivity(string name, string description, List<string> prompts) : base(name, description)
    {
        _prompts = prompts;
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine(" --- " + GetRandomPrompt() + " ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(7);
        Console.WriteLine();

        GetListFromUser();
        Console.WriteLine($"You listed {_count} items!");
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

    private List<string> GetListFromUser()
    {
        List<string> inputs = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write(" > ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                inputs.Add(response);
            }

        }
        _count = inputs.Count();

        return inputs;
    }

}