using System.Collections;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
[JsonSerializable(typeof(FileManager))]
[JsonSourceGenerationOptions(GenerationMode =JsonSourceGenerationMode.Default, PropertyNamingPolicy =JsonKnownNamingPolicy.CamelCase, WriteIndented = true)]
public  class FileManager 
{
    private TeamProject[] _teamProject = new TeamProject[] {};
    private PersonalProject[] _persoProject = new PersonalProject[] {};
    public TeamProject[] TeamProject {get{return _teamProject;}set{_teamProject = value;}}
    public PersonalProject[] PersoProject {get{return _persoProject;} set{_persoProject = value;}}
    public PersonalProject[] GetPersoProject()
    {
        return _persoProject;
    }
    public TeamProject[] GetTeamProject()
    {
        return _teamProject;
    }
    public void SetPersoProject(PersonalProject project)
    {
        _persoProject = _persoProject.Append(project).ToArray();
    }
    public void SetTeamProject(TeamProject project1)
    {
        _teamProject = _teamProject.Append(project1).ToArray();
    }
    public void SaveProject(FileManager poe)
    {
        var save = JsonSerializer.Serialize(poe);
        
        File.WriteAllText("test.json", save);
    }

    public FileManager LoadProject()
    {
        string filePath = "test.json";
        var json = File.ReadAllText(filePath);
        
        var load = JsonSerializer.Deserialize<FileManager>(json);
        return load;
    }
}