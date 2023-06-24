using System;
class Program
{
    static void Main(string[] args)
    {
        List<Goal> goalList = new List<Goal>{};
        int accumulatedPoint = 0;
       
        SimpleGoal s1 = new SimpleGoal();
        EternalGoal e1 = new EternalGoal();
        ChecklistGoal c1 = new ChecklistGoal();
        ManageFile fileManager = new ManageFile();
        while (true) {
            Menu(accumulatedPoint);
            
            Console.Write("Select a choice from the Menu: ");
            int choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("The type of Goals are:");
                    Console.WriteLine(
                        "  1. Simple Goal \n" +
                        "  2. Eternal Goal \n" +
                        "  3. Checklist Goal \n"
                    );
                    Console.Write("Which type of goal would you like to create? ");
                    int type = int.Parse(Console.ReadLine());
                    
                    Console.Write("Enter the name of the goal: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter a description for that goal: ");
                    string description = Console.ReadLine();

                    Console.Write("Enter the amount of point you would like to associate to that goal: ");
                    int awardedPoint = int.Parse(Console.ReadLine());
                    
                    switch (type)
                    {
                        case 1:
                            s1 = new SimpleGoal(name, description,awardedPoint);
                            goalList.Add(s1);
                            break;
                        case 2:
                            e1 = new EternalGoal(name, description,awardedPoint);
                            goalList.Add(e1);
                            
                            break;
                        case 3:

                            Console.Write("How many times does this goal need to be accomplished for a bonus: ");
                            int numOfTIme = int.Parse(Console.ReadLine());

                            Console.Write("What is the bonus fo accomplishing it that many times ? ");
                            int bonusPoint = int.Parse(Console.ReadLine());
                        
                            c1 = new ChecklistGoal(name, description,awardedPoint, numOfTIme, bonusPoint);
                            goalList.Add(c1);
                            break;
                        default:
                            break;
                    }
                    
                    break;
                case 2:
                    Console.WriteLine("The goals are: ");
                    int i = 0;
                    foreach (var goal in goalList)
                    {
                        i++;
                        Console.Write($"   {i}.");
                        Console.WriteLine(goal.Display());
                    }
                    break;
                case 3:
                    Console.Write("Enter the name of the file: ");


                    string fileName = Console.ReadLine();
                    
                    fileManager = new ManageFile(fileName);
                    fileManager.WriteFile(goalList, accumulatedPoint);
                    break;
                case 4:
                    Console.Write("Enter the name of the file: ");
                    string fileName1 = Console.ReadLine();
                    
                    fileManager = new ManageFile(fileName1);
                    goalList = fileManager.ReadFile();
                    accumulatedPoint = fileManager.GetPoints();
                    break;
                case 5:
                    Console.WriteLine("The goals are: ");
                    int k = 1;
                    foreach (var goal in goalList)
                    {
                        Console.WriteLine($"    {k}.{goal.GetGoal()}");
                        k++;
                    }
                    Console.Write("Which goal did you accomplish? ");
                    int accomplishedGoal = int.Parse(Console.ReadLine());
                    accomplishedGoal--;
                    for (int J = 0; J < goalList.Count;){
                        goalList[accomplishedGoal].IsComplete();
                        goalList[accomplishedGoal].RecordEvent();
                        Console.WriteLine(goalList[accomplishedGoal].Display());
                        accumulatedPoint += goalList[accomplishedGoal].GetPoint();
                        break;
                    }

                    break;
                case 6:
                    System.Environment.Exit(1);
                    break;
                
                default:
                    Console.WriteLine("\nInvalid input \nPlease a digit between 1 - 6");
                    break;
            }
            
        }
    }
    public static void Menu(int point){
        Console.WriteLine($"\nYou have {point} points.\n");
            List<string> menu = new List<string>
            {
                "Menu Option:",
                "   1. Create New Goal",
                "   2. List Goals",
                "   3. Save Goals",
                "   4. Load Goals",
                "   5. Record Event",
                "   6. Quit"
            }; 
            foreach (string el in menu)
            {
                Console.WriteLine(el);
            }
    }
}






