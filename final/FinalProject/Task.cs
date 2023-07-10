using System.Text.Json.Serialization;
public class Task : GeneralEntity
{
    [JsonPropertyOrder(6)]
    protected DateOnly _dueDate;
    protected Member _member;
    public Task(){}
    public Task(string title, string description, DateOnly start, DateOnly dueTime, Member member = null, bool status = false)  : base (title, description, status, start)
    {
        _dueDate = dueTime;
        _member = member;
    }
    public Member GetMember()
    {
        return _member;
    }
    public void Member(Member member)
    {
        _member = member;
    }

    public DateOnly GetDueDate()
    {
        return _dueDate;
    }
    public virtual void SetDueDate(int extra)
    {
        _dueDate.AddDays(extra);
    }

    public override string GetEntity()
    {
        return " ";
    }
}