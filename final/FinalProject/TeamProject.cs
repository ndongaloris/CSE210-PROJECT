using System.Text.Json.Serialization;
public class TeamProject : Project
{
    [JsonRequired]
    private List<Member> _teamMember = new List<Member>{};
    [JsonRequired]
    public List<Member> TeamMember {get{return _teamMember;}set{_teamMember=value;}}
    public TeamProject(){}
    public TeamProject(string title, string description, DateOnly start, DateOnly end, List<SimpleTask> tasks = null,List<RecurringTask> tasks2 = null, List<Member> names = null, bool status = false) : base (title, description, start, end, tasks,tasks2, status)
    {
        _teamMember = names;
    }
    public List<Member> GetTeamMember()
    {
        return _teamMember;
    }
    public void SetTeamMember(List<Member> name)
    {
        _teamMember = name;
    }
    
    public override string GetEntity()
    {
        return $"PersonalProject : [{base.RecordEvent()}] {base.GetTitle()} - {base.GetDescription()} - {base.GetStartDate()} - {base.GetDueDate()}";
    }
}