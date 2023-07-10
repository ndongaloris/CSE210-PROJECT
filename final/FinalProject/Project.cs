using System.Text.Json.Serialization;
public class Project : GeneralEntity
{
    [JsonPropertyOrder(5)]
    protected DateOnly _endingDate;
    [JsonPropertyOrder(6)]
    protected List<Task> _tasks = new List<Task>{};
    public Project(){}
    public Project(string title, string description, DateOnly start, DateOnly end, List<Task> tasks, bool status = false): base(title, description, status,start)
    {
        _endingDate = end;
        _tasks = tasks;
    }
    public DateOnly EndingDate{get{return _endingDate;} set{_endingDate = value;}}
    public List<Task> Task {get{return _tasks;}set{_tasks = value;}}
    public List<Task> GetTask()
    {
        return _tasks;
    }
    public void SetTask(List<Task> task)
    {
        _tasks = task;
    }
    public virtual void Display()
    {
        Console.WriteLine();
    }
    public override string GetEntity()
    {
        throw new NotImplementedException();
    }

    public override void IsComplete()
    {
        Console.WriteLine();
    }
    public override string RecordEvent()
    {
        return "";
    }
    public virtual DateOnly GetEndDate()
    {
        return _endingDate;
    }

}