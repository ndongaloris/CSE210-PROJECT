using System.Text.Json.Serialization;
public class PersonalProject : Project
{
    [JsonRequired]
    private string _myName;
    public string Name {get{return _myName;}set{_myName=value;}}
    public PersonalProject(){}
    public PersonalProject(string title, string description, DateOnly start, DateOnly end, string name, List<SimpleTask> tasks = null,List<RecurringTask> tasks2 = null, bool status = false) : base (title, description, start, end, tasks,tasks2, status)
    {
        _myName = name;
    }
    public string GetMyName()
    {
        return _myName;
    }
    public void SetMyName(string name)
    {
        _myName = name;
    }
    public override string GetEntity()
    {
        return $"PersonalProject : [{base.RecordEvent()}] {base.GetTitle()} {base.GetDescription()} {base.GetStartDate()} {base.GetDueDate()}";
    }
}