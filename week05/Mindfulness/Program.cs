// I did the following exceeding requirement: Make sure no random prompts/questions 
//are selected until they have all been used at least once in that session.
//My approach was to create the object outside the loop so when it re-loops it doesn't lose the tracking by creating another one.

using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        List<int> validChoices = new List<int> { 1, 2, 3, 4 };

        List<string> prompts = new List<string>() // reflection activity' prompt list
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        List<string> questions = new List<string>() // reflection activity questions list
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        };

        ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", prompts, questions);


        List<string> promptsList = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", promptsList);


        do
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");


            do
            {
                try
                {
                    Console.Write("Select a choice from the menu: ");
                    choice = int.Parse(Console.ReadLine().Trim());

                    if (!validChoices.Contains(choice))
                    {
                        Console.WriteLine("Answer must be a number from the menu (1, 2, 3 or 4).");
                    }
                }
                catch (System.Exception)
                {
                    choice = 0;
                    Console.WriteLine("Incorrect input, input must be a number of the menu (1, 2, 3 or 4).");
                }
            } while (!validChoices.Contains(choice));


            Console.Clear();

            if (choice == 1) // Breathing Activity
            {
                BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                breathingActivity.Run();

                Console.Clear();
            }

            else if (choice == 2) // Reflecting Activity
            {
                reflectingActivity.Run();

                Console.Clear();

            }

            else if (choice == 3) // Listing Activity
            {
                listingActivity.Run();

                Console.Clear();
            }


        } while (choice != 4);


    }
}