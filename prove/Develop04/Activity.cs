public class Activity
{
    // protected int _durationInSec;
    protected string _description;
    protected string _activityName;
    protected int _timeSpent;
    public Activity(){}
    public Activity(string name, string description, int time = 0)
    {
        _activityName = name;
        _description = description;
        _timeSpent = time;
    }
    public void GetIntroPrompt()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        
        Console.Write("For how long in second would you like for your session to last? ");

        int duration = int.Parse(Console.ReadLine());
        _timeSpent = duration;
        
        Console.Clear();
        
        Console.WriteLine("Get Ready...");
        GetSpinnerTimer();
        Console.WriteLine();

    }
    public void GetSpinnerTimer()
    {   
        List<string> symbol = new List<string>
        {"|","/", "-", "\\", "|", "/", "-", "\\"};
        for (int i = 0; i < symbol.Count() ; i++)
        {
            Console.Write(symbol[i]);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        
    }
    public void GetCountDownTimer(int n = 5)
    {
        if (_timeSpent >= 10)
        {
            for (int i = n; i > 0; i-- )
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        if (_timeSpent < 10)
        {
            for (int i = _timeSpent / 2; i > 0; i-- )
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
    public void GetClosingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done");
        GetSpinnerTimer();
        Console.WriteLine();
        Console.WriteLine($"You have completed a {_timeSpent} of {_activityName}");
        GetCountDownTimer();
        Console.WriteLine();
    }
   
    public void History(int breathing = 0, int reflection = 0, int Listing = 0)
    {
        DateTime CurrentTime = DateTime.Now;
        using(StreamWriter record = File.AppendText("Mindfulness game.txt"))
        {
            record.WriteLine(CurrentTime);
            record.WriteLine($"  The Breathing activity played: {breathing} times.");
            record.WriteLine($"  The Reflection activity played: {reflection} times.");
            record.WriteLine($"  The Listing activity played: {Listing} times.");
            record.WriteLine();
        }
    }

}
