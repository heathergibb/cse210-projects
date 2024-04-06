using System.IO;
using System.Text.RegularExpressions;
public class FileManager
{
    private string _saveDir;

    public FileManager()
    {
        _saveDir = Directory.GetCurrentDirectory() + "\\Ancestors";
    }

    public FileManager(string path)
    {
        _saveDir = path;
    }

    public Person LoadPerson()
    {
        Person newPerson = new Person("Temp","Person","F");
        return newPerson;
    }

    public void SavePerson(Person person)
    {
        Console.WriteLine($"Saving... {person.GetPersonName()}");
        Console.ReadLine();
    }
    public string CreateSaveName(string name)
    {
        // remove all invalid characters and set fileName

        string fileName = Regex.Replace(name, "[^a-zA-Z0-9_]+", String.Empty);
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

        return fileName + ".txt";
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
