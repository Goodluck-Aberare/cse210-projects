using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void RecordGoal(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points!");
            UpdateLevel();
        }
    }

    public void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Score: {_score} | Level: {_level}");
    }

    private void UpdateLevel()
    {
        _level = 1 + (_score / 1000);
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename)) return;

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4])) sg.RecordEvent();
                    _goals.Add(sg);
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[6]));
                    int count = int.Parse(parts[5]);
                    for (int j = 0; j < count; j++)
                    {
                        cg.RecordEvent();
                    }
                    _goals.Add(cg);
                    break;
                case "PersonalDevelopmentGoal":
                    var pd = new PersonalDevelopmentGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4])) pd.RecordEvent();
                    _goals.Add(pd);
                    break;
                case "HealthWellnessGoal":
                    var hw = new HealthWellnessGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4])) hw.RecordEvent();
                    _goals.Add(hw);
                    break;
            }
        }

        UpdateLevel();
    }
}