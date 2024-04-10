public abstract class Event
{
    protected string _date;
    protected string _location;

    public Event(string date, string location)
    {
        _date = date;
        _location = location;
    }
    
    public abstract string DisplayEventString();
    public abstract string FormatSaveString();
}

public class BirthEvent : Event
{
    private string _christeningDate;

    public BirthEvent(string date, string location, string christeningDate) : base(date, location)
    {
        _christeningDate = christeningDate;

        if (date == "" && location == "" && christeningDate == "")
        {
            _date = "No Birth Details";
        }
    }
    public override string DisplayEventString()
    {
        if (_christeningDate == "")
        {
            return $"{_date} {_location}";
        }
        else
        {
            return $"{_date} {_location}  Christening - {_christeningDate}";
        }
    }

    public override string FormatSaveString()
    {
        return $"{_date}|{_location}|{_christeningDate}";
    }
}
public class MarriageEvent : Event
{
    private string _spouse;

    public MarriageEvent(string date, string location, string spouse) : base(date, location)
    {
        _spouse = spouse;

        if (date == "" && location == "" && spouse == "")
        {
            _date = "No Marriage Details";
        }
    }
    public override string DisplayEventString()
    {
        return $"{_date} {_location}  Spouse - {_spouse}";
    }

    public override string FormatSaveString()
    {
        return $"{_date}|{_location}|{_spouse}";
    }
}

public class DeathEvent : Event
{
    private string _burialDate;
    private string _burialLocation;

    public DeathEvent(string date, string location, string burialDate, string burialLocation) : base(date, location)
    {
        _burialDate = burialDate;
        _burialLocation = burialLocation;

        if (date == "" && location == "" && burialDate == "" && burialLocation == "")
        {
            _date = "No Death Details";
        }
    }
    public override string DisplayEventString()
    {
        if (_burialDate == "" && _burialLocation == "")
        {
            return $"{_date} {_location}";
        }
        else
        {
            return $"{_date} {_location}  Burial - {_burialDate} {_burialLocation}";
        }
    }
    public override string FormatSaveString()
    {
        return $"{_date}|{_location}|{_burialDate}|{_burialLocation}";
    }
}
