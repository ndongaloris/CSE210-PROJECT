public abstract class  Goal
{
    //store the title of the goal
    protected string _goalTitle;
    //store the description of the goal
    protected string _description;
    //store the number of points//
    protected int _point;
    protected int _basePoint = 0;
    //determine if box is checked or not
    protected Boolean _check = false;
    //store the original checkbox
    protected string _checkbox = "[ ]";
    
    public Goal(){}

    public Goal(string goal, string description, int point, Boolean check = false)
    {
        _goalTitle = goal;
        _description = description;
        _point += point;
        _check = check;
    }
 
    
    public string GetGoal(){
        return _goalTitle;
    }
    public void SetGoal(string goal)
    {
        _goalTitle = goal;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public int GetPoint()
    {
        return _point;
    }
    public void SetPoint(int point)
    {
        _point = point;
    }
    public int GetBasePoint()
    {
        return _basePoint;
    }
    public virtual string Display()
    {
        return ($"[{GetIsCompleteChar()}] {_goalTitle} {_description}");
     
    }
    public abstract string GetStringRepresentation();
    public abstract Boolean IsComplete();
    public abstract void RecordEvent();
    public virtual char GetIsCompleteChar()
    {
        if(_check)
            return 'X';
        else
            return ' ';
    }
}