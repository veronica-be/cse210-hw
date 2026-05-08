using System;

class Program
{
    static void Main(string[] args)


    {
        int guess;
        int totalGuesses = 0;
        string response;

        do
        {
            Random randomNumber = new Random();
            int magicNumber = randomNumber.Next(1, 100);
            Console.WriteLine();

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                totalGuesses += 1;

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You've got it!!!");
                    Console.WriteLine($"Total of guesses: {totalGuesses}");
                }
            } while (guess != magicNumber);

            Console.WriteLine();
            Console.Write("Do you want to play again? ");
            response = Console.ReadLine();
            totalGuesses = 0;
        } while (response == "yes");
    }
}