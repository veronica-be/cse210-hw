using System;

class Program
{
    static void Main(string[] args)
    {
        // Steps 1-5
        Job job1 = new Job();

        job1._jobTitle = "Software Enginner";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();

        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        //Steps 6-8

        Resume myResume = new Resume();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume._name = "Allison Rose";

        myResume.Display();

    }
}