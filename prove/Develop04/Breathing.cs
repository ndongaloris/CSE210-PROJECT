public class Breathing : Activity
{

        private  string _breathIn;
        //contain the _breath in...string
        private string _breathOut;
        //contain the _breath out...string
        public Breathing(string name, string description, int time = 0) : base (name, description)
        //Inherit from the base
        {
            _breathIn = "Breath in...";
            _breathOut = "Breath out...";
        } 
        public void InAndOut()
        //Display the process of the activity
        {
            if (_timeSpent >= 10)
            {

                int times = base._timeSpent / 10;
                for (int i = 0; i < times; i++)
                {
                    Console.WriteLine();
                    Console.Write(_breathIn);
                    base.GetCountDownTimer();
                    Console.WriteLine();
                    
                    Console.Write(_breathOut);
                    base.GetCountDownTimer();
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine();
                    Console.Write(_breathIn);
                    base.GetCountDownTimer();
                    Console.WriteLine();
                    
                    Console.Write(_breathOut);
                    base.GetCountDownTimer();
                    Console.WriteLine();
                }
            }
        }
}  