public class ChecklistGoal : Goal
{
    /* inherit from the Goal class
     Provide for simple goals that can be marked complete and 
     the user gains some value.
     store the awarded points and check the box when the task 
    is complete also track the points */ 

    private int _awardedPoint;
    private int _numOfTime;
    private int _bonusPoint;
    private int _timeDone;
    //store the awarded points//
    public ChecklistGoal()
    {

    }
    public ChecklistGoal(string goal, string description,int point, int bonusPoint, int numOfTIme, int timeDone = 0, bool check = false) : base(goal, description, point,check)
    //sync with the base constructor//
    {
        _awardedPoint += point;
        _numOfTime = numOfTIme;
        _bonusPoint = bonusPoint;
        _timeDone = timeDone;
    }

     public override Boolean IsComplete()
    {
        _timeDone++;
        if (_numOfTime == _timeDone)
        {
            _check = true;
            _point += _bonusPoint;
        }
        return base._check;
    } 

    // //define if the task is complete or not//
    public override void RecordEvent()
    {
        base._basePoint += _awardedPoint;
        _checkbox = (_check == true ? "[X]" : "[ ]");
        Console.WriteLine($"Congratulations! You have earned {_awardedPoint} points!");
        Console.WriteLine($"You now have {base._basePoint} points");

       
    }
     public override string Display()
     {
        return ($"[{base.GetIsCompleteChar()}] {_goalTitle} {_description} -- current situation: {_timeDone} / {_numOfTime}");
     }
     public override string GetStringRepresentation(){
        return $"ChecklistGoal,{GetGoal()},{GetDescription()},{GetPoint()},{_bonusPoint},{_numOfTime},{_timeDone},{IsComplete()}";
    }

}