public class Resume
{
    public List<Job> _jobs = new List<Job>{};
    public string _person_name;
    public void DisplayResumeDetails()
    {
        Console.WriteLine($"Name: {_person_name}\nJobs: ");
        foreach (Job job in _jobs)
        {
           job.DisplayJobDetails();
        }
    }
}