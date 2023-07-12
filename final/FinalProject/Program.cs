using System.Collections;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        FileManager saveLoad = new FileManager();
        Member person = new Member();
        PersonalProject pProject = new PersonalProject();
        RecurringTask rTask =  new RecurringTask();
        SimpleTask sTask = new SimpleTask();
        TeamProject tProject = new TeamProject();
        
        List<PersonalProject> personal = new List<PersonalProject>();
        List<TeamProject> team = new List<TeamProject>();
        List<Project> projects = new List<Project>{};
        List<Member> people = new List<Member>{};
        Console.Clear();
        while (true)
        {
            Task[] personalTasks = new Task[]{};
            Task[] teamTasks = new Task[]{};
            List<SimpleTask> simTasks = new List<SimpleTask>();
            List<RecurringTask> recTasks = new List<RecurringTask>();
            List<string> menu = new List<string>
            {
                "Menu Option:",
                "   1. Create Project",
                "   2. List Project",
                "   3. Record Event",
                "   4. Delete Project",
                "   5. Delete task",
                "   6. Save Project",
                "   7. Load Project",
                "   8. Quit"
            }; 
            foreach (string el in menu)
            {
                Console.WriteLine(el);
            }
            Console.Write("Please select an option: ");
            int option = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (option)
            {
                case 1:
                    Console.Write("1. Personal Project\n" + 
                                    "2. Team Project\n" +
                                    "Which one 1 or 2: ");
                    int selectedProject = int.Parse(Console.ReadLine());
                    if (selectedProject == 2)
                    {
                        while (true)
                        {
                            Console.Write("Please Enter the name of a member and enter 'quit' if you are done: ");
                            // string memberName = Console.ReadLine();
                            
                            string individual = Console.ReadLine().ToLower();  
                            if (individual == "quit")
                            {
                                break;
                            }
                            person = new Member(individual);
                            people.Add(person);
                        }
                    }
                    
                    Console.Write("Enter the Project title: ");
                    string projectTitle = Console.ReadLine().ToLower();
                    
                    Console.Write("Enter the Project description: ");
                    string projectDescription = Console.ReadLine().ToLower();
                    
                    Console.Write("Enter the Project starting date (mm-dd-yyyy): ");
                    DateOnly projectStartingDate = DateOnly.Parse(Console.ReadLine());
                    
                    Console.Write("Enter the Project ending date (mm-dd-yyyy): ");
                    DateOnly projectEndingDate = DateOnly.Parse(Console.ReadLine());
                    
                    Console.WriteLine("You will now create a task for the project");
                    string addTask;
                    do
                    {
                    Console.Clear();
                        Console.Write("1. Simple Task\n" +
                                        "2. Recurring Task\n" +
                                        "Which one : ");
                        int taskType = int.Parse(Console.ReadLine());
                            
                        Console.Write("Enter the Task title: ");
                        string taskTitle = Console.ReadLine().ToLower();
                        
                        Console.Write("Enter the Task description: ");
                        string taskDescription = Console.ReadLine().ToLower();
                        
                        Console.Write("Enter the Task starting date (mm-dd-yyyy): ");
                        DateOnly taskStartingDate = DateOnly.Parse(Console.ReadLine());
                        
                        Console.Write("Enter the due date (mm-dd-yyyy): ");
                        DateOnly dueTime = DateOnly.Parse(Console.ReadLine());
                        if (taskType == 1)
                        {
                            if (selectedProject == 1 )
                            { 
                                sTask = new SimpleTask(taskTitle, taskDescription, dueTime, taskStartingDate);
                                personalTasks.Append(sTask); 
                                simTasks.Add(sTask);
                            } 
                            else
                            {
                                int m = 1;
                                foreach (Member member in people)
                                {
                                    Console.WriteLine($"{m}. {member.GetName()}");
                                    m++;
                                }
                                Console.Write("which of this member will you assign the Task to: ");
                                int assignedMember = int.Parse(Console.ReadLine());
                                assignedMember--;
                                sTask = new SimpleTask(taskTitle, taskDescription, dueTime, taskStartingDate, people[assignedMember]);
                                teamTasks.Append(sTask);
                                simTasks.Add(sTask);
                            }
                        }
                        else
                        {
                            Console.Write("How many time do you want it to be done: ");
                            int numOfTime = int.Parse(Console.ReadLine());
                            if (selectedProject == 1 )
                            { 
                                rTask = new RecurringTask(taskTitle, taskDescription, taskStartingDate, dueTime, numOfTime);
                                personalTasks.Append(rTask);
                                recTasks.Add(rTask);
                            } 
                            else
                            {
                                int m = 1;
                                foreach (Member member in people)
                                {
                                    Console.WriteLine($"{m}. {member.GetName()}");
                                }
                                Console.Write("which of this member will you assign the Task to: ");
                                int assignedMember = int.Parse(Console.ReadLine());
                                assignedMember--;
                                rTask = new RecurringTask(taskTitle, taskDescription, taskStartingDate, dueTime, numOfTime, people[assignedMember]);
                                teamTasks.Append(rTask);
                                recTasks.Add(rTask);
                            }
                        }
                        
                        Console.Write("Do you want to add another Task: ");
                        addTask = Console.ReadLine().ToLower();
                        Console.Clear();
                    }while (addTask != "no");
                    
                    if (selectedProject == 1)
                    {
                        Console.Write("Please Enter your Name: ");
                        string myName =  Console.ReadLine();
                        
                        pProject = new PersonalProject(projectTitle, projectDescription, projectStartingDate, projectEndingDate, myName,simTasks, recTasks);
                        projects.Add(pProject);
                        personal.Add(pProject);
                    }
                    else if (selectedProject == 2)
                    {
                        tProject = new TeamProject(projectTitle, projectDescription, projectStartingDate, projectEndingDate, simTasks,recTasks, tProject.GetTeamMember());
                        projects.Add(tProject);
                        team.Add(tProject);
                        tProject.SetTeamMember(people);
                        // tProject.SetTask(teamTasks);
                        
                    }
                    else
                    {
                        { };
                    }
                    Console.Clear();
                    break;
                case 2:
                    Console.Write("1. Personal Project\n" + 
                                    "2. Team Project\n" +
                                    "Which one 1 or 2: ");
                    int selectedProject2 = int.Parse(Console.ReadLine());
                    if (selectedProject2 == 1)
                    {
                        int p = 1;
                        foreach (var project in personal)
                        {
                            Console.WriteLine($"{p}. {project.GetTitle()}");
                        }p++;
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject5 = int.Parse(Console.ReadLine());
                        selectedProject5--;
                        for (int i = 0; i < personal.Count(); i++)
                        {
                            int t0 = 1;
                            Console.WriteLine(personal[selectedProject5].GetEntity());
                            Console.Write("Would you like to display the tasks yes or no: ");
                            string taskDisplay =  Console.ReadLine(); 
                            if (taskDisplay == "yes")
                            {
                                foreach (Task task in personal[selectedProject5].GetTask())
                                {
                                    Console.WriteLine($"   {t0}. {task.GetEntity()}");
                                    t0++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (selectedProject2 == 2)
                    {
                        int p = 1;
                        foreach (var project in team)
                        {
                            Console.WriteLine($"{p}. {project.GetTitle()}");
                            p++;
                        }
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject5 = int.Parse(Console.ReadLine());
                        selectedProject5--;
                        for (int i = 0; i < team.Count(); i++)
                        {
                            int t = 1;
                            Console.WriteLine(team[selectedProject5].GetEntity());
                            Console.Write("Would you like to display the tasks yes or no: ");
                            string taskDisplay2 =  Console.ReadLine(); 
                            if (taskDisplay2 == "yes")
                            {
                                foreach (Task task in team[selectedProject5].GetTask())
                                {
                                    Console.WriteLine($"   {t}. {task.GetEntity()}");
                                    t++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                        Console.WriteLine();
                    break;
                case 3:
                    Console.Write("1. Personal Project\n" + 
                                    "2. Team Project\n" +
                                    "Which one 1 or 2: ");
                    int selectedProject9 = int.Parse(Console.ReadLine());
                    if (selectedProject9 == 1)
                    {
                        
                        int p = 1;
                        foreach (var project in personal)
                        {
                            Console.WriteLine($"{p}. {project.GetEntity()}");
                            p++;
                        }
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject4 = int.Parse(Console.ReadLine());
                        selectedProject4--;
                        for (int i = 0; i < personal.Count(); i++)
                        {
                            int c = 1;
                            Console.WriteLine(personal[selectedProject4].GetEntity());
                            
                            Console.WriteLine("Here are the task: ");
                            var listOfTaskInProject = personal[selectedProject4].GetTask();
                            foreach (Task task in listOfTaskInProject)
                            {
                                Console.WriteLine($"  {c}. {task.GetEntity()}");
                            }
                            Console.Write("Which one would you like to record: ");
                            int toBeRecorded = int.Parse(Console.ReadLine());
                            toBeRecorded--;
                            listOfTaskInProject[toBeRecorded].IsComplete();
                            listOfTaskInProject[toBeRecorded].RecordEvent();
                            bool allTask = false;
                            foreach (Task task in listOfTaskInProject)
                            {
                                allTask = (task.GetStatus() == true ?true: false);
                            }
                            if (allTask == true)
                            {
                                personal[selectedProject4].IsComplete();
                                personal[selectedProject4].RecordEvent();
                            }
                        }
                    }
                    else if (selectedProject9 == 2)
                    {
                        int p = 1;
                        foreach (var project in team)
                        {
                            Console.WriteLine($"{p}. {project.GetEntity()}");
                            p++;
                        }
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject5 = int.Parse(Console.ReadLine());
                        selectedProject5--;
                        for (int i = 0; i < team.Count(); i++)
                        {
                            int c = 1;
                            Console.WriteLine(team[selectedProject5].GetEntity());
                            
                            Console.WriteLine("Here are the task: ");
                            var listOfTaskInProject = team[selectedProject5].GetTask();
                            foreach (Task task in listOfTaskInProject)
                            {
                                Console.WriteLine($"  {c}. {task.GetEntity()}");
                            }
                            Console.Write("Which one would you like to record: ");
                            int toBeRecorded = int.Parse(Console.ReadLine());
                            toBeRecorded--;
                            listOfTaskInProject[toBeRecorded].IsComplete();
                            listOfTaskInProject[toBeRecorded].RecordEvent();
                            bool allTask = false;
                            foreach (Task task in listOfTaskInProject)
                            {
                                allTask = (task.GetStatus() == true?true: false);
                            }
                            if (allTask == true)
                            {
                                team[selectedProject5].IsComplete();
                                team[selectedProject5].RecordEvent();
                            }
                        }
                    }
                    Console.Clear();
                    break;
                case 4:
                Console.Write("1. Personal Project\n" + 
                                    "2. Team Project\n" +
                                    "Which one 1 or 2: ");
                    int selectedProject3 = int.Parse(Console.ReadLine());
                    if (selectedProject3 == 1)
                    {
                        int p = 1;
                        foreach (var project in personal)
                        {
                            Console.WriteLine($"{p}. {project.GetEntity()}");
                            p++;
                        }
                        Console.Write("Which project would you like to delete from the list? ");
                        int taskToRemove = int.Parse(Console.ReadLine());
                        taskToRemove--;
                        for (int i = 0; i < personal.Count(); i++)
                        {
                            personal.RemoveAt(taskToRemove);
                        }
                    }
                    else if (selectedProject3 == 2)
                    {
                        int p = 1;
                        foreach (var project in team)
                        {
                            Console.WriteLine($"{p}. {project.GetEntity()}");
                            p++;
                        }
                        Console.Write("Which project would you like to delete from the list? ");
                        int taskToRemove = int.Parse(Console.ReadLine());
                        taskToRemove--;
                        for (int i = 0; i < team.Count(); i++)
                        {
                            team.RemoveAt(taskToRemove);
                        }
                    }
                    Console.Clear();
                    break;
                case 5:
                Console.Write("1. Personal Project\n" + 
                                    "2. Team Project\n" +
                                    "Which one 1 or 2: ");
                    int selectedProject30 = int.Parse(Console.ReadLine());
                    if (selectedProject30 == 1)
                    {
                        int p = 1;
                        foreach (var project in personal)
                        {
                            Console.WriteLine($"{p}. {project.GetTitle()}");
                            p++;
                        }
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject4 = int.Parse(Console.ReadLine());
                        selectedProject4--;
                        for (int i = 0; i < personal.Count(); i++)
                        {
                            int d = 1;
                            Console.WriteLine(personal[selectedProject4].GetEntity());
                            
                            Console.WriteLine("Here are the task: ");
                            var listOfTaskInProject = personal[selectedProject4].GetTask();
                            foreach (Task task in listOfTaskInProject)
                            {
                                Console.WriteLine($"  {d}. {task.GetEntity()}");
                            }
                            Console.Write("Which one would you like to remove: ");
                            int toBeRemoved = int.Parse(Console.ReadLine());
                            toBeRemoved--;
                            if(personal[selectedProject4].GetSimpleTask().Contains(listOfTaskInProject[toBeRemoved]))
                            {
                                personal[selectedProject4].GetSimpleTask().Remove((SimpleTask)listOfTaskInProject[toBeRemoved]);
                            }
                            else if(personal[selectedProject4].GetRecurringTask().Contains(listOfTaskInProject[toBeRemoved]))
                            {
                                personal[selectedProject4].GetRecurringTask().Remove((RecurringTask)listOfTaskInProject[toBeRemoved]);
                            }
                            
                        }
                    }
                    else if (selectedProject30 == 2)
                    {
                        int p = 1;
                        foreach (var project in team)
                        {
                            Console.WriteLine($"{p}. {project.GetTitle()}");
                            p++;
                        }
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject5 = int.Parse(Console.ReadLine());
                        selectedProject5--;
                        if (selectedProject30 == 1)
                        {
                            int p1 = 1;
                            foreach (var project in team)
                            {
                                Console.WriteLine($"{p1}. {project.GetEntity()}");
                                p1++;
                            }
                            Console.Write("Enter the number of the project you want select: " );
                            int selectedProject4 = int.Parse(Console.ReadLine());
                            selectedProject4--;
                            for (int i = 0; i < team.Count(); i++)
                            {
                                int d = 1;
                                Console.WriteLine(team[selectedProject4].GetEntity());
                                
                                Console.WriteLine("Here are the task: ");
                                var listOfTaskInProject = team[selectedProject4].GetTask();
                                foreach (Task task in listOfTaskInProject)
                                {
                                    Console.WriteLine($"  {d}. {task.GetEntity()}");
                                }
                                Console.Write("Which one would you like to remove: ");
                                int toBeRemoved = int.Parse(Console.ReadLine());
                                toBeRemoved--;
                                if(team[selectedProject4].GetSimpleTask().Contains(listOfTaskInProject[toBeRemoved]))
                                {
                                    personal[selectedProject4].GetSimpleTask().Remove((SimpleTask)listOfTaskInProject[toBeRemoved]);
                                }
                                else if(team[selectedProject4].GetRecurringTask().Contains(listOfTaskInProject[toBeRemoved]))
                                {
                                    personal[selectedProject4].GetRecurringTask().Remove((RecurringTask)listOfTaskInProject[toBeRemoved]);
                                }
                            }
                        }
                    }
                    Console.Clear();
                    break;
                case 6:
                    foreach (var project in personal)
                    {
                        saveLoad.SetPersoProject(project);
                    }
                    foreach (var project in team)
                    {
                        saveLoad.SetTeamProject(project);
                    }
                    saveLoad.SaveProject(saveLoad);
                    break;
                case 7:
                var load = saveLoad.LoadProject();
                    projects.Clear();
                    foreach(var element in load.persoProject0)
                    {
                        personal.Clear();
                        projects.Add(element);
                        personal.Add(element);
                    }
                    foreach(var element in load.GetTeamProject())
                    {
                        team.Clear();
                        projects.Add(element);
                        team.Add(element);
                    }
                    break;
                case 8:
                    Environment.Exit(1);
                    break;
                default:
                    break;
            }
        }
    }
}