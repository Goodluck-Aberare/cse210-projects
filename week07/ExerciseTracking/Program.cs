using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 12, 10), 30, 4.8),
            new Cycling(new DateTime(2025, 12, 10), 45, 20.0),
            new Swimming(new DateTime(2025, 12, 10), 40, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}