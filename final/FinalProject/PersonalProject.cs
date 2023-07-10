public class PersonalProject : Project
{
    private List<Project> projects = new List<Project>{};
    public PersonalProject(){}
    public PersonalProject(string title, string description, DateOnly start, DateOnly end, List<Task> tasks, bool status = false) : base (title, description, start, end, tasks, status)
    {
        base._tasks = tasks;
    }

    public List<Project> GetProject()
    {
        return projects;
    }
    public void SetProject(Project project)
    {
        projects.Add(project);
    }
    public override void Display()
    {
        int i = 1;
        foreach (Project project in projects)
        {
            Console.WriteLine($"{i}. {project.GetTitle()}");
            i++;
        }
    }
    public override string GetEntity()
    {
        return $"PersonalProject : [{base.RecordEvent()}] {base.GetTitle()} {base.GetDescription()} {base.GetStartDate()} {base.GetEndDate()}";
    }
}