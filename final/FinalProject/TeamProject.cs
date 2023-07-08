public class TeamProject : Project
{
    private List<Member> _teamMember = new List<Member>{};
    private List<Project> projects = new List<Project>{};
    public TeamProject(){}
    public TeamProject(string title, string description, DateOnly start, DateOnly end, List<Task> tasks, List<Member> names, bool status = false) : base (title, description, start, end, tasks, status)
    {
        _teamMember = names;
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
    public List<Member> GetTeamMember()
    {
        return _teamMember;
    }
    public void SetTeamMember(List<Member> name)
    {
        _teamMember = name;
    }
    public List<Task> GetTeamTask()
    {
        return base._tasks;
    }
    public void SetTeamTask(List<Task> task)
    {
        base._tasks = task;
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
        return $"PersonalProject : [{base.RecordEvent()}] {base.GetTitle()} - {base.GetDescription()} - {base.GetStartDate()} - {base.GetEndDate()}";
    }
}