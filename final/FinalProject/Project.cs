using System.Text.Json.Serialization;
public abstract class Project : GeneralEntity
{

    [JsonPropertyOrder(6)]                        
    protected List<SimpleTask> _simple = new List<SimpleTask>{};
    [JsonRequired]
    protected List<RecurringTask> _recurring = new List<RecurringTask>{};
    public Project(){}
    public Project(string title, string description, DateOnly start, DateOnly dueTime, List<SimpleTask> tasks = null,List<RecurringTask> tasks2 = null, bool status = false): base(title, description, status,start, dueTime)
    {
        _simple = tasks;
        _recurring = tasks2;
    }
    public List<SimpleTask> Simple {get{return _simple;}set{_simple = value;}}
    public List<RecurringTask> Recursing {get{return _recurring;}set{_recurring= value;}}
    public List<Task> GetTask()
    {
        List<Task> tasks = new List<Task>{};
        foreach(var task1 in _simple)
        {
            tasks.Add(task1);
        }
        foreach(var task2 in _recurring)
        {
            tasks.Add(task2);
        }
        return tasks;
    }

    public List<RecurringTask> GetRecurringTask()
    {
        return _recurring;
    }
    public List<SimpleTask> GetSimpleTask()
    {
        return _simple;
    }
    }