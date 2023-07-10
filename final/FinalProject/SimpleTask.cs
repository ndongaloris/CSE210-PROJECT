public class SimpleTask : Task
{
    private TimeSpan _normalFrequency;
    public SimpleTask(){}
    public SimpleTask(string title, string description, DateOnly start, DateOnly dueTime, Member member = null, bool status = false) : base (title, description, dueTime, start, member, status)
    {
        _normalFrequency = new TimeSpan();
    }
    public override string GetEntity()
    {
        if(base._member == null)
        {
            return $"SimpleTask: [{base.RecordEvent()}] - {base.GetTitle()} - {base.GetDescription()} - {base.GetStartDate()} - {base.GetDueDate()}";
        }
        else
        {
            return $"SimpleTask: [{base.RecordEvent()}] - {base.GetTitle()} - {base.GetDescription()} - {base.GetStartDate()} - {base.GetDueDate()} by {base.GetMember().GetName()}";
        }
    }

}