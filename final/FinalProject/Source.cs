using System.Reflection.Metadata.Ecma335;

public class Source
{
    private string _description;
    private string _date; // string dates may be entered as a range or partial date
    private string _location;
    private string _submittedBy;

    public Source(string desc, string date, string location, string submittedBy)
    {
        _description = desc;
        _date = date;
        _location = location;
        _submittedBy = submittedBy;
    }

    public string FormatListDisplay()
    {
        // allow for "" variables and format string accordingly

        string displayString = "";
        
        if (_description != "")
        {
            displayString = $"{_description}\n";
        }

        if (_date != "" && _location != "")
        {
            displayString += $"{_date}, {_location}\n";
        }
        else if (_date != "")
        {
            displayString += $"{_date}\n";
        }
        else if (_location != "")
        {
            displayString += $"{_location}\n";
        }

        if (_submittedBy != "")
        {
            displayString += $"Submitted By: {_submittedBy}\n";
        }
        return displayString;
    }

    public string FormatSaveString()
    {
        return $"{_description}|{_date}|{_location}|{_submittedBy}";
    }
}