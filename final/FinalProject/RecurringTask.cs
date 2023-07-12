using System;
using System.Text.Json.Serialization;
public class RecurringTask : Task
{
    [JsonRequired]
    private int? _toDo;
    [JsonRequired]
    private int? _numOfTimeDOne = 0;
    public int? ToDo {get{return _toDo;}set{_toDo = value;}}
    public int? _NumOfTimeDOneo {get{return _numOfTimeDOne;}set{_numOfTimeDOne = value;}}
    public RecurringTask(){}
    public RecurringTask(string title, string description, DateOnly start, DateOnly dueTime, int numOfTime, Member member = null, bool status =  false) : base (title, description, start, dueTime,member, status)
    {
        _toDo = numOfTime;
    }
    public override void IsComplete()
    {
        _numOfTimeDOne++;
        Recurring();
        base._status = (_numOfTimeDOne == _toDo? true : false);
    }
    public void Recurring()
    {
        int difference = base.GetDueDate().Day - base.GetStartDate().Day;
        DateOnly extraS = _startingDate.AddDays(difference);
        DateOnly extraD = _dueDate.AddDays(difference);
        SetDueDate(extraD);
        SetStartDate(extraS);
    }
    public override string GetEntity()
    {
        if (base._member == null)
        {
            return $"RecurringTask:[{base.RecordEvent()}] {base.GetTitle()} {base.GetDescription()} {base.GetStartDate()} {base.GetDueDate()} --- Done {_numOfTimeDOne} / {_toDo}";
        }
        else
        {
            return $"RecurringTask:[{base.RecordEvent()}] {base.GetTitle()} {base.GetDescription()} {base.GetStartDate()} {base.GetDueDate()} --- Done {_numOfTimeDOne} / {_toDo} by {base.GetMember().GetName()}";
        }
    }
}