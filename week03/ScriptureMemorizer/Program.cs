using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Scripture Memorizer\n");

        // Scripture Library
        List<Scripture> scriptures = new List<Scripture>
{
    new Scripture(
        new ScriptureReference("John", 3, 16),
        "For God so loved the world that he gave his only begotten Son"),

    new Scripture(
        new ScriptureReference("Proverbs", 3, 5, 6),
        "Trust in the Lord with all thine heart and lean not unto thine own understanding"),

    new Scripture(
        new ScriptureReference("Alma", 37, 6),
        "By small and simple things are great things brought to pass"),

    new Scripture(
        new ScriptureReference("Mosiah", 2, 17),
        "When ye are in the service of your fellow beings ye are only in the service of your God"),

    new Scripture(
        new ScriptureReference("Ether", 12, 27),
        "If men come unto me I will show unto them their weakness that they may be humble"),

    new Scripture(
        new ScriptureReference("Matthew", 5, 16),
        "Let your light so shine before men that they may see your good works"),

    new Scripture(
        new ScriptureReference("Psalms", 23, 1),
        "The Lord is my shepherd I shall not want"),

    new Scripture(
        new ScriptureReference("Helaman", 5, 12),
        "It is upon the rock of our Redeemer who is Christ the Son of God that ye must build your foundation"),

    new Scripture(
        new ScriptureReference("2 Nephi", 2, 25),
        "Adam fell that men might be and men are that they might have joy"),

    new Scripture(
        new ScriptureReference("D&C", 88, 63),
        "Draw near unto me and I will draw near unto you")
};

        // Pick a random scripture
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("\nPress Enter to hide words or type 'quit': ");

            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            // Hide 2–3 random words each round
            scripture.HideRandomWords(3);

            if (scripture.AllHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending...");
                break;
            }
        }
    }
}
