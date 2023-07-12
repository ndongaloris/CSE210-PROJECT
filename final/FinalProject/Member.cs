using System.Text.Json.Serialization;
public class Member
{
    [JsonRequired]
    private string _name;
    public string Name {get{return _name;}set{_name = value;}}
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