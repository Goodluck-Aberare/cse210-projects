public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                IsComplete = true;
                return Points + _bonus;
            }
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return $"[{(IsComplete ? "X" : " ")}] {Name} - {Description} (Completed {_currentCount}/{_targetCount})";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_currentCount}|{_bonus}|{IsComplete}";
    }
}