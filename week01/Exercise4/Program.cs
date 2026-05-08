using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers (whole numbers, positive or negative), type 0 when finished.");
        Console.WriteLine("");
        int response;

        do
        {
            Console.Write("Enter number: ");
            response = int.Parse(Console.ReadLine());
            if (response != 0)
            {
                numbers.Add(response);
            }
        } while (response != 0);


        //summary
        int listSum = numbers.Sum();

        float average = (float)listSum / numbers.Count; //note for myself: if the division is with integers no matter 
        // if the variable is a float the result will be an int. You must type (float) to make at least one float so C# understand that you want a float.
        // Or use: usign System.Linq;  numbers.Average() 

        int largestNumber = numbers[0];
        int smallestPositive = numbers[0];

        foreach (int number in numbers)
        {
            if (number > largestNumber)
            {
                largestNumber = number;
            }
            else if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }

        }

        Console.WriteLine($"The sum is: {listSum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine($"The sorted list is:");

        numbers.Sort();
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }

}