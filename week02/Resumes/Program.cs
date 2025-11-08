using System;

class Program
{
    static void Main(string[] args)
    {
        // Create first job
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // Create second job
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "True Light Analytics";
        job2._startYear = 2022;
        job2._endYear = 2025;

        // Create resume and add jobs
        Resume myResume = new Resume();
        myResume._name = "Goodluck Aberare";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display resume
        myResume.Display();
    }
}