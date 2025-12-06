public class PersonalDevelopmentGoal : SimpleGoal
{
    public PersonalDevelopmentGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override string Serialize()
    {
        return $"PersonalDevelopmentGoal|{Name}|{Description}|{Points}|{IsComplete}";
    }
}