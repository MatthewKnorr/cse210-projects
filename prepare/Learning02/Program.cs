using System;

class Program
{
    static void Main(string[] args)
    {
        Job jobOne = new Job();
        jobOne._jobTitle = "Student";
        jobOne._company = "BYU-I";
        jobOne._startYear = 2021;
        jobOne._endYear = 2024;
        jobOne.Display();
        
        Job jobTwo = new Job();
        jobTwo._jobTitle = "Barista";
        jobTwo._company = "Starbucks";
        jobTwo._startYear = 2019;
        jobTwo._endYear = 2023;
        jobTwo.Display();

        Resume myResume = new Resume();
        myResume._name = "Matthew Knorr";

        myResume._jobs.Add(jobOne);
        myResume._jobs.Add(jobTwo);

        myResume.Display();

         

    }

    
}