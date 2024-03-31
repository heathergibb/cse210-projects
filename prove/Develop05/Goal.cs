public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    
    public string GetShortName()
    {
        return _shortName;
    }
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string check = " ";
        if (IsComplete())
        { 
            check = "X";
        }
        return $"[{check}] {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}