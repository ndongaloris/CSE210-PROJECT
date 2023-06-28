public class PromptGenerator
{
    public string _title;
    public string _sentence;
    public string _prompt;
    public string _author;
    public string _goal;
    public List<string> _promptsList = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
    public void PromptsDisplay()
    // a method that will print the current time and date and also generate 
    // a random string from the list
    {
        var date = new DateTime();  //get the date and time
        date = DateTime.Now; //get the current date and time

        var random = new Random(); //generate the random method
        int index = random.Next(_promptsList.Count()); //get the total of string in the list and store it as index
        _prompt = _promptsList[index]; // select a random string from the list and store it into the variable

        Console.Write($"{_prompt}\n>");

        _sentence = Console.ReadLine();
    }
    public void MoreInfo() //create a title and the name of the person writing.
    {
        
        Console.Write("Describe you day in two to three words \nNote this will be the title of this section:");
        _title = Console.ReadLine();

        Console.Write("Enter your name to record the name of the author: ");
        _author = Console.ReadLine();
    }
    public string Goals()
    {
        //entice the user to set goals and track his progression
        Console.WriteLine("\nSet a goal that you will be working on this week or this month,");
        Console.WriteLine("then you can record your progression. what would you like to do?");
        Console.Write("1. Create a new Goal \n 2. Record my progression \n  3. None from the above option:");
        int decision = int.Parse(Console.ReadLine());
        if (decision == 1)
        {
            Console.Write("Enter your goal: \n");
            _goal = Console.ReadLine().ToUpper();
            return _goal;
        }
        else if (decision == 2)
        {
            Console.Write("Did you progress in you goal? (Y/N):");
            string progress = Console.ReadLine().ToUpper();
            if (progress == "Y")
            {
                Console.Write("How much have you progress with your goal:\n");
                _goal = Console.ReadLine();
            } 
            else if (progress == "N")
            {
                Console.Write("What will you do different this time to meet your goal?:\n");
                _goal = Console.ReadLine();
            }    
            return _goal;

        }
        else if (decision == 3)
        {
            Console.WriteLine("Alright, but remember goals keep you moving forward.");
            return null;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return null;
        }
    }
}