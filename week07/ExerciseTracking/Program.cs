using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Environment.NewLine + "Hello World! This is the ExerciseTracking Project." + Environment.NewLine);

        List<Activity> activities = new List<Activity>();

        Running running = new Running(4.8, 30);
        activities.Add(running);

        Cycling cycling = new Cycling(10, 60);
        activities.Add(cycling);

        Swimming swimming = new Swimming(5, 30);
        activities.Add(swimming);

        foreach (var activity in activities)
        {
            string stringOfDetails = activity.GetSummary();
            Console.WriteLine(stringOfDetails);
        }

        Console.WriteLine();
    }
}