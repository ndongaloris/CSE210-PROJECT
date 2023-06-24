public abstract class  Goal
{
    //store the title of the goal
    protected string _goalTitle;
    //store the description of the goal
    protected string _description;
    //store the number of points//
    protected int _point;
    //determine if box is checked or not
    protected Boolean _check = false;
    //store the original checkbox
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
 
    public string GetDescription()
    {
        return _description;
    }
   
    public int GetPoint()
    {
        return _point;
    }
    
    public virtual string Display()
    {
        return ($"[{GetIsCompleteChar()}] {_goalTitle} {_description}");
     
    }
    public abstract string GetStringRepresentation();
    public abstract Boolean IsComplete();
    public abstract void RecordEvent(int point);
    public virtual char GetIsCompleteChar()
    {
        if(_check)
            return 'X';
        else
            return ' ';
    }
}