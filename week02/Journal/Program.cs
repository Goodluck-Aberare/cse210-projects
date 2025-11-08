using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"Date: {Date.ToShortDateString()}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What surprised me today?",
        "What did I learn today that I didn’t know before?",
        "What small win am I proud of today?",
        "What’s one thing I’m grateful for today?",
        "What’s something I avoided today and why?"
    };

    public void WriteNewEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        entries.Add(new Entry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        });

        Console.WriteLine("✅ Entry saved!\n");
    }

    public void DisplayJournal()
    {
        Console.WriteLine("\n--- 📖 Journal Entries ---");
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
        Console.WriteLine();
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("💾 Journal saved successfully!\n");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            entries.Clear();
            foreach (var line in File.ReadAllLines(filename))
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new Entry
                    {
                        Date = DateTime.Parse(parts[0]),
                        Prompt = parts[1],
                        Response = parts[2]
                    });
                }
            }
            Console.WriteLine("📂 Journal loaded successfully!\n");
        }
        else
        {
            Console.WriteLine("⚠️ File not found.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("  🌟 Welcome to SafeSpace Journal 🌟");
        Console.WriteLine("  Your private place to reflect, grow, and heal.");
        Console.WriteLine("======================================\n");

        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("📋 Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("❌ Invalid option. Try again.\n");
                    break;
            }
        }

        Console.WriteLine("\n🙏 Thank you for using SafeSpace Journal. Take care and keep reflecting!");
    }
}