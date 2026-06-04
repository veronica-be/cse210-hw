public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    { }

    public void Run()
    {
        DisplayStartingMessage();

        int times = GetDuration() / 10;
        int remainder = GetDuration() % 10;

        List<List<int>> listSecondsForRemainders = new List<List<int>>()
        {
            new List<int> {1, 1},  // if duration == 1 (or remainder)
            new List<int> {2 , 2}, // duration ++ until 9 seconds
            new List<int> {3 , 2},
            new List<int> {2 , 2},
            new List<int> {2 , 3},
            new List<int> {3 , 3},
            new List<int> {3, 4},
            new List<int> {4, 4},
            new List<int> {4, 5}
        };

        if (remainder > 0)
        {
            List<int> seconds = new List<int>();
            seconds = listSecondsForRemainders[remainder - 1];

            Console.Write("Breathe in ...   ");
            ShowCountDown(seconds[0]);
            Console.Write("Now breathe out ...");
            ShowCountDown(seconds[1]);

            Console.WriteLine();
        }

        if (times > 0)
        {
            for (int i = 0; i < times; i++)
            {
                Console.Write("Breathe in ...   ");
                ShowCountDown(4);
                Console.Write("Now breathe out ...");
                ShowCountDown(6);

                Console.WriteLine();
            }
        }

        Console.WriteLine();

        DisplayEndingMessage();
    }


}