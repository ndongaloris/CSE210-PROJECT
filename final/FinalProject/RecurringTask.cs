using Newtonsoft.Json;
using System;
public class RecurringTask : Task
{
    private int _toDo;
    private int _numOfTimeDOne = 0;
    public RecurringTask(){}
    public RecurringTask(string title, string description, DateOnly start, DateOnly dueTime, int numOfTime, Member member = null, bool status =  false) : base (title, description, start, dueTime,member, status)
    {
        _toDo = numOfTime;
    }
    public override void IsComplete()
    {
        _numOfTimeDOne++;
        int difference = base.GetDueDate().Day - base.GetStartDate().Day;
        _startingDate.AddDays(difference);
        _dueDate.AddDays(difference);
        base._status = (_numOfTimeDOne == _toDo? true : false);
    }
    public void repeatTime()
    {
        
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