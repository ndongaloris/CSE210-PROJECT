public class EternalGoal : Goal
{
    private int _awardedPoint;
    public EternalGoal()
    {

    }
    public EternalGoal(string goal, string description, int point) : base(goal, description, point)
    //sync with the base constructor//
    {
        _awardedPoint += point;
    }

     public override Boolean IsComplete()
    {
        return base._check = true;
    } 

    public override void RecordEvent()
    {
        base._basePoint += _awardedPoint;
        Console.WriteLine($"Congratulations! You have earned {_awardedPoint} points!");
        Console.WriteLine($"You now have {base._basePoint} points");
    }
    public override char GetIsCompleteChar()
    {
        if(_check)
            return ' ';
        else
            return ' ';
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal,{GetGoal()},{GetDescription()},{GetPoint()}";
    }

}