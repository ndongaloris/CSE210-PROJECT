using System.Collections;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
[JsonSerializable(typeof(FileManager))]
[JsonSourceGenerationOptions(GenerationMode =JsonSourceGenerationMode.Default, PropertyNamingPolicy =JsonKnownNamingPolicy.CamelCase, WriteIndented = true)]
public  class FileManager 
{
    private TeamProject[] _teamProject1 = new TeamProject[] {};
    private PersonalProject[] _persoProject1 = new PersonalProject[] {};
    public TeamProject[] teamProject1 {get{return _teamProject1;}set{_teamProject1 = value;}}
    public PersonalProject[] persoProject0 {get{return _persoProject1;} set{_persoProject1 = value;}}
    public PersonalProject[] GetPersoProject()
    {
        return _persoProject1;
    }
    public TeamProject[] GetTeamProject()
    {
        return _teamProject1;
    }
    public void SetPersoProject(PersonalProject project)
    {
        _persoProject1 = _persoProject1.Append(project).ToArray();
    }
    public void SetTeamProject(TeamProject project1)
    {
        _teamProject1 = _teamProject1.Append(project1).ToArray();
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