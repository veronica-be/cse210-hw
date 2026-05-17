// There is a mood traking, each journal entry captures the user's mood cause that way we resolve the problem that people often forget how they felt when they re-read it.
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        string action;
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        generator._prompts.Add("What was the most challenging moment of my day, and how did I handle it?");
        generator._prompts.Add("What is your main expectation or goal for tomorrow?");
        generator._prompts.Add("When did I feel the most peaceful or happy today?");
        generator._prompts.Add("What is something new I learned or realized today?");
        generator._prompts.Add("If I had one thing I could do over today, what would it be?");



        do
        {
            Console.WriteLine("");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("    1. Write");
            Console.WriteLine("    2. Display");
            Console.WriteLine("    3. Load");
            Console.WriteLine("    4. Save");
            Console.WriteLine("    5. Quit");

            do
            {
                Console.Write("What would you like to do? ");
                action = Console.ReadLine().Trim();

                if (action == "1")
                {
                    Console.Write("");
                    string randomPrompt = generator.GetRandomPrompt();
                    Console.WriteLine(randomPrompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("Rate your mood from 1 = terrible to 5 = great: ");
                    string mood = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();
                    Entry entry = new Entry(date, randomPrompt, response, mood);
                    journal.AddEntry(entry);
                }

                else if (action == "2")
                {
                    journal.DisplayAll();

                }

                else if (action == "3")
                {
                    Console.WriteLine("");
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine().Trim();
                    journal.LoadFromFile(filename);



                }

                else if (action == "4")
                {
                    Console.WriteLine("");
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine();
                    journal.SaveToFile(filename);

                    Console.WriteLine($"Journal has been saved to '{filename}'.");
                }

                else if (action == "5")
                {
                    Console.Write("Bye!");
                }

                else
                {
                    Console.WriteLine("Please type a valid option.");
                }
            } while (action != "1" && action != "2" && action != "3" && action != "4" && action != "5");

        } while (action != "5");

    }
}