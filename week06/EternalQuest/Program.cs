using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        string file = "goals.txt";

        while (true)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Goal Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.ShowGoals();
                    Console.Write("Enter goal number to record: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                        manager.RecordGoal(index - 1);
                    break;
                case "3":
                    manager.ShowGoals();
                    break;
                case "4":
                    manager.ShowScore();
                    break;
                case "5":
                    manager.Save(file);
                    Console.WriteLine("Goals saved.");
                    break;
                case "6":
                    manager.Load(file);
                    Console.WriteLine("Goals loaded.");
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Personal Development Goal");
        Console.WriteLine("5. Health & Wellness Goal");
        Console.Write("Your choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int pts = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, pts));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, pts));
                break;
            case "3":
                Console.Write("How many times to complete? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus on completion: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, desc, pts, target, bonus));
                break;
            case "4":
                manager.AddGoal(new PersonalDevelopmentGoal(name, desc, pts));
                break;
            case "5":
                manager.AddGoal(new HealthWellnessGoal(name, desc, pts));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }
}