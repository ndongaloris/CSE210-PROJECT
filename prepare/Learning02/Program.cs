using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "System Administrator";
        job1._company = "Microsoft";
        job1._startYear = 2023;
        job1._endYear = 2025;

        Job job2 = new Job();
        job2._jobTitle = "Database administrator";
        job2._company = "Apple";
        job2._startYear = 2025;
        job2._endYear = 2027;
        
        Job job3 = new Job();
        job3._jobTitle = "Software Developer";
        job3._company = "Google";
        job3._startYear = 2027;
        job3._endYear = 2030;

        Resume my_resume = new Resume();
        my_resume._person_name = "Sarah Ndonga";
        my_resume._jobs.Add(job1);
        my_resume._jobs.Add(job2);
        my_resume._jobs.Add(job3);
        my_resume.DisplayResumeDetails();
    }
          
}