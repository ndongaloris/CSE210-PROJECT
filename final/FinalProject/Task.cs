using System.Text.Json.Serialization;

public abstract class Task : GeneralEntity
{
    [JsonRequired]
    protected Member _member;
    public Member Member {get{return _member;}set{_member = value;}}
    public Task(){}
    public Task(string title, string description, DateOnly start, DateOnly dueTime, Member member = null, bool status = false)  : base (title, description, status, start, dueTime)
    {
        _member = member;
    }
    public Member GetMember()
    {
        return _member;
    }
    public void SetMember(Member member)
    {
        _member = member;
    }
}