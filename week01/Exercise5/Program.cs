using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        static int SquareNumber(int numberGiven)
        {
            int result = (int)Math.Pow(numberGiven, 2); //I know I could just multiply it, but I like to learn new ways to do it.
            return result;
        }

        static void DisplayResult(string userName, int squaredNumber)
        {
            Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
        }

        static void Main()
        {
            DisplayWelcome();

            string name = PromptUserName();
            int number = PromptUserNumber();
            int squaredNumber = SquareNumber(number);

            DisplayResult(name, squaredNumber);
        }

        Main();
    }
}