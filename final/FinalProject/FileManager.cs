using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;
public class FileManager
{
    private string _saveDir;

    public FileManager()
    {
        _saveDir = Directory.GetCurrentDirectory() + "\\Ancestors";
        VerifyAncestorsFolderExists();
    }

    public FileManager(string path)
    {
        // this method is not currently used but it allows for future functionality 
        // that would allow the user to pick a different save location than the default
        _saveDir = path;
    }

    public Person LoadPerson(string path)
    {
        // load all the details from the .txt file

        string[] lines = System.IO.File.ReadAllLines(path);
        int i = 0;

        string[] parts = lines[i].Split("|");
        string fileName = parts[0];
        string givenName = parts[1];
        string lastName = parts[2];
        string sex = parts[3]; 
        i++;
        
        Person newPerson = new Person(givenName, lastName, sex);

        newPerson.SetFileName(fileName);

        //Import Events
        parts = lines[i].Split("|"); 
        BirthEvent birth = new BirthEvent(parts[0],parts[1],parts[2]);
        newPerson.SetBirth(birth);
        i++;

        parts = lines[i].Split("|");
        MarriageEvent marriage = new MarriageEvent(parts[0],parts[1],parts[2]);
        newPerson.SetMarriage(marriage);
        i++;

        parts = lines[i].Split("|");
        DeathEvent death = new DeathEvent(parts[0],parts[1],parts[2],parts[3]);
        newPerson.SetDeath(death);
        i++;

        //Import Ordinances
        parts = lines[i].Split("|"); //baptism
        Ordinance baptism = new Ordinance(bool.Parse(parts[0]),parts[1],parts[2],parts[3]);
        newPerson.SetBaptism(baptism);
        i++;

        parts = lines[i].Split("|"); //confirmation
        Ordinance confirmation = new Ordinance(bool.Parse(parts[0]),parts[1],parts[2],parts[3]);
        newPerson.SetConfirmation(confirmation);
        i++;

        parts = lines[i].Split("|"); //initiatory
        Ordinance initiatory = new Ordinance(bool.Parse(parts[0]),parts[1],parts[2],parts[3]);
        newPerson.SetInitiatory(initiatory);
        i++;

        parts = lines[i].Split("|"); //endowment
        Ordinance endowment = new Ordinance(bool.Parse(parts[0]),parts[1],parts[2],parts[3]);
        newPerson.SetEndowment(endowment);
        i++;

        parts = lines[i].Split("|"); //Sealing to Spouse
        SealingSpouse sealingS = new SealingSpouse(bool.Parse(parts[0]),parts[1],parts[2],parts[3],parts[4]);
        newPerson.SetSealingSpouse(sealingS);
        i++;

        parts = lines[i].Split("|"); //sealing to Parents
        SealingParents sealingP = new SealingParents(bool.Parse(parts[0]),parts[1],parts[2],parts[3],parts[4],parts[5]);
        newPerson.SetSealingParents(sealingP);       
        i++;

        //Import Sources
        List<Source> sources = new List<Source>();
        for (int line = i;  line < lines.Count(); line++)
        {
            parts = lines[line].Split("|");
            Source s = new Source(parts[0],parts[1],parts[2],parts[3]);
            sources.Add(s);
        }
        newPerson.SetSources(sources);
        newPerson.SetChanged(false);

        return newPerson;
    }

    public void SavePerson(string fileName, List<string> saveData)
    {
        // save all the details to a .txt file
        string path = $"{_saveDir}\\{fileName}.txt";

        using (StreamWriter outputFile = new StreamWriter(path))
        {
            foreach (string line in saveData)
            {
                outputFile.WriteLine(line);
            }
        }
        
        Console.WriteLine("Save complete. Press Enter to continue...");
        Console.ReadLine();
    }
    public string ValidateSaveName(string fileName)
    {
        // remove all invalid characters and set fileName
        //validate fileName, if not valid then create new one
        fileName = Regex.Replace(fileName, "[^a-zA-Z0-9_]+", String.Empty);
        string[] existingFileNames = GetFileNames();
        
        bool nameExists;
        string baseName = fileName;
        int appendNum = 0;

        do
        {
            nameExists = false;
            foreach (string file in existingFileNames)
            {
                // check to see if file name already exists
                if (Path.GetFileNameWithoutExtension(file) == fileName)
                {
                    nameExists = true;
                    appendNum += 1;
                    fileName = baseName + appendNum;
                    break;
                }
            }
        }
        while (nameExists);

        return fileName;
    }
    public string[] GetFileNames()
    {
        // return a list of file name containing Person details
        string[] files = Directory.GetFiles(_saveDir,"*.txt");
        
        return files;
    }
    public void VerifyAncestorsFolderExists()
    {
        // If directory does not exist, create it
        if (!Directory.Exists(_saveDir))
        {
            Directory.CreateDirectory(_saveDir);
        }
    }  
}
