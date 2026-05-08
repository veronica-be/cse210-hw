using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string name = Console.ReadLine();

        Console.Write("What is your last name? ");
        string LastName = Console.ReadLine();

        Console.WriteLine();
        Console.Write($"Your name is {LastName}, {name} {LastName}.");
    }
}