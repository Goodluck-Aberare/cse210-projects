using System;

class Program
{
    static void Main()
    {
        // Prompt user for grade percentage
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        string letter = "";
        string sign = "";

        // Determine letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine sign (except for A+, F+, F-)
        int lastDigit = grade % 10;
        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Display final grade
        Console.WriteLine($"\nYour letter grade is: {letter}{sign}");

        // Check pass/fail
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying! You'll do better next time.");
        }
    }
}