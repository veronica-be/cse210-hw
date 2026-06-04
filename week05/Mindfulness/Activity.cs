public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity." + Environment.NewLine + Environment.NewLine + _description + Environment.NewLine);

        int duration;
        do
        {
            try
            {
                Console.Write("How long, in seconds, would you like for your session?    > ");
                duration = int.Parse(Console.ReadLine().Trim());

                if (duration <= 0)
                {
                    Console.WriteLine("Must be more than 0 seconds.");
                }
            }
            catch (System.Exception)
            {
                duration = 0;
                Console.WriteLine("Incorrect input, input must be a whole number.");
            }
        } while (!(duration > 0));

        _duration = duration;

        Console.Clear();

        Console.WriteLine(Environment.NewLine + "Get ready...");
        ShowSpinner(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(5);

        string word = "seconds";
        if (_duration == 1)
        {
            word = "second";
        }

        Console.WriteLine($"You have completed {_duration} {word} of the {_name} Activity.");
        ShowSpinner(10);
    }

    public void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        List<string> spinnerAnimation = new List<string> { "|", "/", "―", "\\" };

        while (DateTime.Now < endTime)
        {
            if (i > (spinnerAnimation.Count - 1))
            {
                i = 0;
            }

            string s = spinnerAnimation[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            i++;
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public int GetDuration()
    {
        return _duration;
    }
}