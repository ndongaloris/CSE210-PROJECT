public class Assignment
{
    protected string _studentName;
    protected string _topic;
    protected Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }
    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }
    public string GetSummary()
    {
        return _topic + " by " + _studentName;
    }
    
}