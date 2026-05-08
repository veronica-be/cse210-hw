using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int score = int.Parse(Console.ReadLine());
        int lastDigit = score % 10;

        bool A = score >= 90;
        bool B = score >= 80;
        bool C = score >= 70;
        bool D = score >= 60;

        string letter;
        string sign;

        if (A)
        {
            letter = "A";
        }

        else if (B)
        {
            letter = "B";
        }

        else if (C)
        {
            letter = "C";
        }

        else if (D)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        if (lastDigit >= 7)
        {
            sign = "+";

            if (letter == "A" || letter == "F")
            {
                sign = "";
            }
        }
        else if (lastDigit < 3)
        {
            sign = "-";

            if (letter == "F" || score >= 100 ) //score, cause sometimes students can have extra credit, and since when they get 100% the remainer is 0 so I get a minus, which is incorrect. 
            {
                sign = "";
            }
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is {letter}{sign}.");

        if (score >= 70)
        {
            Console.WriteLine("Congrats!! You have passed the class.");
        }
        else
        {
            Console.WriteLine("Practice and learn more. Do not give up!");
        }
    }
}