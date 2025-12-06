public class HealthWellnessGoal : SimpleGoal
{
    public HealthWellnessGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override string Serialize()
    {
        return $"HealthWellnessGoal|{Name}|{Description}|{Points}|{IsComplete}";
    }
}