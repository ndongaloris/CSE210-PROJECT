using System.Xml.Schema;
using System;
using System.IO;
public class ManageFile
{
    string _fileName = "myFile.txt";
    int _points;
    List<Goal> _object = new List<Goal> { };
    public ManageFile() { }
    public ManageFile(string fileName)
    {
        _fileName = fileName;
    }
    public List<Goal> ReadFile()
    {
         string[] lines = File.ReadAllLines(_fileName);
        _points = int.Parse(lines[0]);
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            switch (parts[0])
            {
                case "SimpleGoal":
                    SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                    _object.Add(goal);
                    break;
                case "EternalGoal":
                    EternalGoal goal2 = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                    _object.Add(goal2);
                    break;
                case "ChecklistGoal":
                    ChecklistGoal goal3 = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]),bool.Parse(parts[7]));
                    _object.Add(goal3);
                    break;
            }
        }
 
        return _object;
    }
    public int GetPoints()
    {
        return _points;
    }

    public void WriteFile(List<Goal> goals, int points)
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            // You can add text to the file with the WriteLine method
            outputFile.WriteLine($"{points}");
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine($"{goal.GetStringRepresentation()}");
            }
        }
    }


}