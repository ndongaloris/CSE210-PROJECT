using System.Text.Json.Serialization;
public abstract class GeneralEntity
{
    [JsonPropertyOrder(1)]
    protected string _title;
    [JsonPropertyOrder(2)]
    protected string _description;
    [JsonPropertyOrder(3)]
    protected bool _status = false;
    [JsonPropertyOrder(4)]
    protected DateOnly _startingDate;
    [JsonPropertyOrder(5)]
    protected DateOnly _dueDate;
    public GeneralEntity(){}
    public GeneralEntity(string title, string description, bool status, DateOnly start, DateOnly dueTime)
    {
        _title = title;
        _description = description; 
        _startingDate = start; 
        _dueDate = dueTime;
        _status = status;
    }
    public string Title {get{return _title;}set{_title = value;}}
    public string Description {get{return _description;}set{_description = value;}}
    public bool Status {get{return _status;}set{_status = value;}}
    public DateOnly StartingDate {get{return _startingDate;}set{_startingDate = value;}}
    public DateOnly DueDate {get{return _dueDate;}set{_dueDate = value;}}
    public string GetTitle()
    {
        return _title;
    }
    public void SetTitle(string title)
    {
        _title = title;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public bool GetStatus()
    {
        return _status;
    }
    public void SetStatus(bool status)
    {
        _status = status;
    }
    public DateOnly GetStartDate()
    {
        return _startingDate;
    }
    public void SetStartDate(DateOnly date)
    {
        _startingDate = date ;
    }
    public virtual void SetDueDate(DateOnly date)
    {
        _dueDate = date;
    }
    public DateOnly GetDueDate()
    {
        return _dueDate;
    }
    public virtual void IsComplete()
    {
        _status = true;
    }
    public string RecordEvent()
    {
        if (_status)
        {
            return "X";
        }
        else 
        {
            return " ";
        }
    }
    public abstract string GetEntity();
}