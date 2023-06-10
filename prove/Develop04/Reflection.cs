public class Reflection : Activity
{
     private List<string> _thinkPromptList = new List<string>
    //store a list on prompt that the user will use to think
     {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
     } ;
        private List<string> _reflectQuestion = new List<string>
        //store the list of question to depend the thinkprompt question
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        public Reflection(string name, string description) : base (name, description)
        //inherit from the base
        {

        }
        public void GetPrompt()
        //ask the think
        {
            Console.WriteLine("Consider the following prompt: ");
            Console.WriteLine();

            Random random = new Random();
            int index = random.Next(_thinkPromptList.Count);
            
            Console.WriteLine($" ---{_thinkPromptList[index]}---");
            Console.WriteLine();
        }
        public void GetQuestion()
        //display random questions to depend the reflection
        {
            Console.Write("When you have something in mind, please press the Enter key to continue: ");
            string enter = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Now ponder each of the following questions as they are related to this experience.");
            Console.Write("You may begin in: ");
            base.GetCountDownTimer();

            Console.Clear();

            if (_timeSpent >= 10)
            {
                int times = base._timeSpent / 10;
                for (int i = 0; i < times; i++)
                {
                    Random random = new Random();
                    int index = random.Next(_reflectQuestion.Count);
                    Console.Write($" > {_reflectQuestion[index]}");
                    base.GetSpinnerTimer();
                    Console.WriteLine();
                }
            }   
            else
            {
                for (int i = 0; i < 1; i++)
                {
                    Random random = new Random();
                    int index = random.Next(_reflectQuestion.Count);
                    Console.Write($" > {_reflectQuestion[index]}");
                    base.GetSpinnerTimer();
                    Console.WriteLine();
                }
            }
        }
}