using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            int magicNumber = random.Next(1, 101); // Random number between 1 and 100
            int guessCount = 0;
            int guess;

            Console.WriteLine("Welcome to the Number guessing Game, I'm thinking of a number between 1 and 100...");

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("🎯 You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }

            } while (guess != magicNumber);

            Console.Write("\nDo you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing! 👋");
    }
}