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
        TeamProject tProject = new TeamProject();
        SimpleTask sTask = new SimpleTask();
        RecurringTask rTask =  new RecurringTask();
        
        List<Member> people = new List<Member>{};
        List<PersonalProject> personalProjects = new List<PersonalProject>{};
        List<TeamProject> teamProjects = new List<TeamProject>{};
        ArrayList pro = new ArrayList();
        Console.Clear();
        while (true)
        {
            List<Task> personalTasks = new List<Task>(){};
            List<Task> teamTasks = new List<Task>(){};
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
                            Console.Write("Please Enter the name of a member: ");
                            // string memberName = Console.ReadLine();
                            
                            string individual = Console.ReadLine();  
                            if (individual == "quit")
                            {
                                break;
                            }
                            person = new Member(individual);
                            people.Add(person);
                        }
                    }
                    
                    Console.Write("Enter the Project title: ");
                    string projectTitle = Console.ReadLine();
                    
                    Console.Write("Enter the Project description: ");
                    string projectDescription = Console.ReadLine();
                    
                    Console.Write("Enter the Project starting date: ");
                    DateOnly projectStartingDate = DateOnly.Parse(Console.ReadLine());
                    
                    Console.Write("Enter the Project ending date: ");
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
                        string taskTitle = Console.ReadLine();
                        
                        Console.Write("Enter the Task description: ");
                        string taskDescription = Console.ReadLine();
                        
                        Console.Write("Enter the Task starting date: ");
                        DateOnly taskStartingDate = DateOnly.Parse(Console.ReadLine());
                        
                        Console.Write("Enter the due date: ");
                        DateOnly dueTime = DateOnly.Parse(Console.ReadLine());

                        if (taskType == 1)
                        {
                            if (selectedProject == 1 )
                            { 
                                sTask = new SimpleTask(taskTitle, taskDescription, dueTime, taskStartingDate);
                                personalTasks.Add(sTask); 
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
                                teamTasks.Add(sTask);
                            }
                        }
                        else
                        {
                            Console.Write("How many time do you want it to be done: ");
                            int numOfTime = int.Parse(Console.ReadLine());
                            if (selectedProject == 1 )
                            { 
                                rTask = new RecurringTask(taskTitle, taskDescription, taskStartingDate, dueTime, numOfTime);
                                personalTasks.Add(rTask); 
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
                                teamTasks.Add(rTask);
                            }
                        }
                        
                        Console.Write("Do you want to add another Task: ");
                        addTask = Console.ReadLine();
                        Console.Clear();
                        pro.Add(personalProjects);
                        pro.Add(teamProjects);
                    }while (addTask != "no");
                    
                    if (selectedProject == 1)
                    {
                        Console.Write("Please Enter your Name: ");
                        string myName =  Console.ReadLine();
                        
                        pProject = new PersonalProject(projectTitle, projectDescription, projectStartingDate, projectEndingDate, personalTasks);
                        pProject.SetProject(pProject);
                        personalProjects.Add(pProject);
                        pProject.SetTask(personalTasks);
                        saveLoad.SetPersoProject(pProject);
                    }
                    else if (selectedProject == 2)
                    {
                        tProject = new TeamProject(projectTitle, projectDescription, projectStartingDate, projectEndingDate, teamTasks, tProject.GetTeamMember());
                        tProject.SetProject(tProject);
                        tProject.SetTeamMember(people);
                        teamProjects.Add(tProject);
                        // tProject.SetTeamTask(teamTasks);
                        tProject.SetTask(teamTasks);
                        saveLoad.SetTeamProject(tProject);
                    }
                    else
                    {
                        { };
                    }
                    break;
                case 2:
                    Console.Write("1. Personal Project\n" + 
                                    "2. Team Project\n" +
                                    "Which one 1 or 2: ");
                    int selectedProject2 = int.Parse(Console.ReadLine());
                    if (selectedProject2 == 1)
                    {
                        pProject.Display();
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject5 = int.Parse(Console.ReadLine());
                        selectedProject5--;
                        for (int i = 0; i < pProject.GetProject().Count(); i++)
                        {
                            Console.WriteLine(pProject.GetProject()[selectedProject5].GetEntity());
                            Console.Write("Would you like to display the tasks yes or no: ");
                            string taskDisplay =  Console.ReadLine(); 
                            if (taskDisplay == "yes")
                            {
                                foreach (Task task in pProject.GetProject()[selectedProject5].GetTask())
                                {
                                    Console.WriteLine(task.GetEntity());
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
                        tProject.Display();
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject5 = int.Parse(Console.ReadLine());
                        selectedProject5--;
                        for (int i = 0; i < tProject.GetProject().Count(); i++)
                        {
                            Console.WriteLine(tProject.GetProject()[selectedProject5].GetEntity());
                            Console.Write("Would you like to display the tasks yes or no: ");
                            string taskDisplay2 =  Console.ReadLine(); 
                            if (taskDisplay2 == "yes")
                            {
                                foreach (Task task in tProject.GetProject()[selectedProject5].GetTask())
                                {
                                    Console.WriteLine(task.GetEntity());
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                        {
                            // foreach( Project project in pProjects)
                            // {
                            //     project.Display();
                            // }
                            Console.Write("Enter the number of the project you want select: " );
                            int selectedProject6 = int.Parse(Console.ReadLine());
                            selectedProject6--;
                            for (int z = 0; z < pProject.GetProject().Count(); z++)
                            {
                                Console.WriteLine(pProject.GetProject()[selectedProject6].GetEntity());
                                Console.Write("Would you like to display the tasks yes or no: ");
                                string taskDisplay1 =  Console.ReadLine(); 
                                if (taskDisplay1 == "yes")
                                {
                                    foreach (Task task in pProject.GetProject()[selectedProject6].GetTask())
                                    {
                                        Console.WriteLine(task.GetEntity());
                                    }
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
                        pProject.Display();
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject4 = int.Parse(Console.ReadLine());
                        selectedProject4--;
                        for (int i = 0; i < pProject.GetProject().Count(); i++)
                        {
                            Console.WriteLine(pProject.GetProject()[selectedProject4].GetEntity());
                            
                            Console.WriteLine("Here are the task: ");
                            var listOfTaskInProject = pProject.GetProject()[selectedProject4].GetTask();
                            foreach (Task task in listOfTaskInProject)
                            {
                                Console.WriteLine(task.GetEntity());
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
                                pProject.GetProject()[selectedProject4].IsComplete();
                                pProject.GetProject()[selectedProject4].RecordEvent();
                            }
                        }
                    }
                    else if (selectedProject9 == 2)
                    {
                        tProject.Display();
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject5 = int.Parse(Console.ReadLine());
                        selectedProject5--;
                        for (int i = 0; i < tProject.GetProject().Count(); i++)
                        {
                            Console.WriteLine(tProject.GetProject()[selectedProject5].GetEntity());
                            
                            Console.WriteLine("Here are the task: ");
                            var listOfTaskInProject = tProject.GetProject()[selectedProject5].GetTask();
                            foreach (Task task in listOfTaskInProject)
                            {
                                Console.WriteLine(task.GetEntity());
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
                                tProject.GetProject()[selectedProject5].IsComplete();
                                tProject.GetProject()[selectedProject5].RecordEvent();
                            }
                        }
                    }
                    break;
                case 4:
                Console.Write("1. Personal Project\n" + 
                                    "2. Team Project\n" +
                                    "Which one 1 or 2: ");
                    int selectedProject3 = int.Parse(Console.ReadLine());
                    if (selectedProject3 == 1)
                    {
                        pProject.Display();
                        Console.Write("Which project would you like to delete from the list? ");
                        int taskToRemove = int.Parse(Console.ReadLine());
                        taskToRemove--;
                        for (int i = 0; i < pProject.GetProject().Count(); i++)
                        {
                            pProject.GetProject().RemoveAt(taskToRemove);
                        }
                    }
                    else if (selectedProject3 == 2)
                    {
                        tProject.Display();
                        Console.Write("Which project would you like to delete from the list? ");
                        int taskToRemove = int.Parse(Console.ReadLine());
                        taskToRemove--;
                        for (int i = 0; i < tProject.GetProject().Count(); i++)
                        {
                            tProject.GetProject().RemoveAt(taskToRemove);
                        }
                    }
                    break;
                case 5:
                Console.Write("1. Personal Project\n" + 
                                    "2. Team Project\n" +
                                    "Which one 1 or 2: ");
                    int selectedProject30 = int.Parse(Console.ReadLine());
                    if (selectedProject30 == 1)
                    {
                        pProject.Display();
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject4 = int.Parse(Console.ReadLine());
                        selectedProject4--;
                        for (int i = 0; i < pProject.GetProject().Count(); i++)
                        {
                            Console.WriteLine(pProject.GetProject()[selectedProject4].GetEntity());
                            
                            Console.WriteLine("Here are the task: ");
                            var listOfTaskInProject = pProject.GetProject()[selectedProject4].GetTask();
                            foreach (Task task in listOfTaskInProject)
                            {
                                Console.WriteLine(task.GetEntity());
                            }
                            Console.Write("Which one would you like to remove: ");
                            int toBeRemoved = int.Parse(Console.ReadLine());
                            toBeRemoved--;
                            listOfTaskInProject.RemoveAt(toBeRemoved);
                            
                        }
                    }
                    else if (selectedProject30 == 2)
                    {
                        tProject.Display();
                        Console.Write("Enter the number of the project you want select: " );
                        int selectedProject5 = int.Parse(Console.ReadLine());
                        selectedProject5--;
                        if (selectedProject30 == 1)
                        {
                            tProject.Display();
                            Console.Write("Enter the number of the project you want select: " );
                            int selectedProject4 = int.Parse(Console.ReadLine());
                            selectedProject4--;
                            for (int i = 0; i < tProject.GetProject().Count(); i++)
                            {
                                Console.WriteLine(tProject.GetProject()[selectedProject4].GetEntity());
                                
                                Console.WriteLine("Here are the task: ");
                                var listOfTaskInProject = tProject.GetProject()[selectedProject4].GetTask();
                                foreach (Task task in listOfTaskInProject)
                                {
                                    Console.WriteLine(task.GetEntity());
                                }
                                Console.Write("Which one would you like to remove: ");
                                int toBeRemoved = int.Parse(Console.ReadLine());
                                toBeRemoved--;
                                listOfTaskInProject.RemoveAt(toBeRemoved);
                            }
                        }
                    }
                    break;
                case 6:
                    saveLoad.SaveProject(saveLoad);
                    break;
                case 7:
                var load = saveLoad.LoadProject();
                    foreach(var element in load.GetPersoProject())
                    {
                        pProject.SetProject(element);
                    }
                    foreach(var element in load.GetTeamProject())
                    {
                        tProject.SetProject(element);
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