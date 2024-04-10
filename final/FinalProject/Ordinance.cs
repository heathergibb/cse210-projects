public class Ordinance
{
    protected bool _completed;
    protected string _date;
    protected string _location;
    protected string _type;

    public Ordinance(string type)
    {
        _type = type;
        _completed = false;
    }
    public Ordinance(bool completed, string date, string location, string type)
    {
        _completed = completed;
        _date = date;
        _location = location;
        _type = type;
    }

    public virtual string DisplayOrdinanceString()
    {
        string ordString;

        if (_completed)
        {
            ordString = $"{_type} - {_date} {_location}";
        }
        else
        {
            ordString = $"{_type} - Not Complete";
        }

        return ordString;   
    }

    public virtual string FormatSaveString()
    {
        return $"{_completed}|{_date}|{_location}|{_type}";
    }
}

public class SealingSpouse : Ordinance
{
    private string _spouse;

    public SealingSpouse(string type) : base(type)
    {
        _completed = false;
        _spouse = "";
    }
    public SealingSpouse(bool completed, string date, string location, string type, string spouse) : base(completed, date, location, type)
    {
        _spouse = spouse;
    }

    public override string DisplayOrdinanceString()
    {
        string ordString;

        if (_completed)
        {
            ordString = $"{_type} - {_date} {_location} Spouse: {_spouse}";
        }
        else
        {
            ordString = $"{_type} - Not Complete";
        }

        return ordString;
    }

    public override string FormatSaveString()
    {
        return $"{_completed}|{_date}|{_location}|{_type}|{_spouse}";
    }
}

public class SealingParents : Ordinance
{
    private string _father;
    private string _mother;

    public SealingParents(string type) : base(type)
    {
        _completed = false;
        _father = "";
        _mother = "";
    }
    public SealingParents(bool completed, string date, string location, string type, string father, string mother) : base(completed, date, location, type)
    {
        _father = father;
        _mother = mother;
    }

    public override string DisplayOrdinanceString()
    {
        string ordString;

        if (_completed)
        {
            ordString = $"{_type} - {_date} {_location} Father: {_father} and Mother: {_mother} ";
        }
        else
        {
            ordString = $"{_type} - Not Complete";
        }

        return ordString;
    }
    public override string FormatSaveString()
    {
        return $"{_completed}|{_date}|{_location}|{_type}|{_father}|{_mother}";
    }
}