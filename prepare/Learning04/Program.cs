using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "loris";
        string topic = "Coding";
        string section = "7.5";
        string problem = "3-5";
        string title = "inheritance learning with C#";
        
        MathAssignment Math = new MathAssignment(name, topic, section, problem);
        Console.WriteLine(Math.GetSummary());
        Console.WriteLine(Math.GetHomeworkList());
        
        WritingAssignment Write = new WritingAssignment(name, topic, title);
        Console.WriteLine(Write.GetSummary());
        Console.WriteLine(Write.GerWritingInformation());
    }
}