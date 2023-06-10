 public class Listing : Activity
 {
    private List<string> _promptList = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    } ;
            //store the a list of question for the user//
    private List<string> _inputList = new List<string>{} ;
    //store the a list of answer from the user//
    public Listing(string name, string description) : base (name, description)
    //inherit from the base//
    {

    }
    public void GetQuestion() 
    //Ask and Display random question and wait for the answer//
    //Display the number of question answered//
    {
        Random random = new Random();
        int index = random.Next(_promptList.Count);
        
        Console.WriteLine($" ---{_promptList[index]}---");
        Console.WriteLine();
        
        Console.WriteLine("Now ponder each of the following questions as they are related to this experience.");
        Console.Write("You may begin in: ");
        base.GetCountDownTimer();
        Console.WriteLine();
        int time = base._timeSpent * 100;
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_timeSpent);

        while (true)
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime < futureTime)
            {
                GetInput();
            }
            else
            {
                break;
            }
        }
        
        Console.WriteLine($"You have listed {_inputList.Count} items!");
    }
    public void GetInput()
    //Get the answer from t
    {
        Console.Write($"  > ");
        string input = Console.ReadLine();
        _inputList.Add(input);
    }
}