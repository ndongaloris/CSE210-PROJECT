public class Member
{
    private string _name;
    public Member(){}
    public Member(string name)
    {
        _name = name;
    }
    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }
}