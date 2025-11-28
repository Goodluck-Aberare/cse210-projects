using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MindfulActivitiesApp
{
    // Base class for activities
    abstract class Activity
    {
        private readonly string _name;
        private readonly string _description;
        private int _durationSeconds;

        protected static Random _random = new Random();

        // Static session log (counts how many times each activity ran)
        private static Dictionary<string, int> _sessionLog = new Dictionary<string, int>();

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string Name => _name;
        private string Description => _description;

        // Duration property (seconds)
        public int DurationSeconds
        {
            get => _durationSeconds;
            private set
            {
                if (value < 1) throw new ArgumentException("Duration must be at least 1 second.");
                _durationSeconds = value;
            }
        }

        // Public entry point for running the activity
        public void Start()
        {
            Console.Clear();
            ShowStartingMessage();
            PromptForDuration();
            PrepareToBegin();
            RunActivity(); // implemented in derived classes
            ShowEndingMessage();
            IncrementLog();
        }

        // Derived classes override to implement activity-specific behavior
        protected abstract void RunActivity();

        // Common starting message
        protected void ShowStartingMessage()
        {
            Console.WriteLine($"=== {_name} ===");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
        }

        // Ask user for duration in seconds
        private void PromptForDuration()
        {
            while (true)
            {
                Console.Write("Enter duration for this activity in seconds (e.g., 30): ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int seconds) && seconds > 0)
                {
                    DurationSeconds = seconds;
                    break;
                }
                Console.WriteLine("Please enter a valid positive integer for seconds.");
            }
        }

        // Prepare pause with animation
        private void PrepareToBegin()
        {
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            PauseWithDots(3);
        }

        // Common ending message
        protected void ShowEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            PauseWithDots(2);
            Console.WriteLine($"You have completed the {_name} for {DurationSeconds} seconds.");
            PauseWithDots(3);
        }

        // Spinner animation for given seconds
        protected void PauseWithSpinner(int seconds)
        {
            char[] spinner = new char[] { '|', '/', '-', '\\' };
            Stopwatch sw = Stopwatch.StartNew();
            int i = 0;
            while (sw.Elapsed.TotalSeconds < seconds)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(250);
                Console.Write('\b');
                i++;
            }
            sw.Stop();
        }

        // Countdown numeric display for given seconds
        protected void PauseWithCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Dots animation
        protected void PauseWithDots(int seconds)
        {
            Stopwatch sw = Stopwatch.StartNew();
            while (sw.Elapsed.TotalSeconds < seconds)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine();
            sw.Stop();
        }

        // Increment session log for this activity
        private void IncrementLog()
        {
            if (_sessionLog.ContainsKey(Name))
                _sessionLog[Name]++;
            else
                _sessionLog[Name] = 1;
        }

        // Static method to print the session log
        public static void PrintSessionLog()
        {
            Console.WriteLine();
            Console.WriteLine("=== Session Activity Log ===");
            if (_sessionLog.Count == 0)
            {
                Console.WriteLine("No activities performed yet.");
            }
            else
            {
                foreach (var kv in _sessionLog)
                {
                    Console.WriteLine($"{kv.Key}: {kv.Value} time(s)");
                }
            }
            Console.WriteLine();
        }
    }

    // Breathing Activity
    class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        protected override void RunActivity()
        {
            Console.WriteLine();
            Console.WriteLine("Follow the prompts. We'll alternate inhale and exhale.");
            Console.WriteLine();

            Stopwatch sw = Stopwatch.StartNew();
            bool breatheIn = true;

            // We'll choose a reasonable breath cycle; however we respect total duration.
            // Each prompt will be followed by a countdown of, say, 4 seconds.
            int promptPause = 4;

            while (sw.Elapsed.TotalSeconds < DurationSeconds)
            {
                if (breatheIn)
                {
                    Console.Write("Breathe in... ");
                }
                else
                {
                    Console.Write("Breathe out... ");
                }

                // Show numeric countdown but cap so we don't overshoot total time
                int secondsLeft = DurationSeconds - (int)sw.Elapsed.TotalSeconds;
                int pause = Math.Min(promptPause, Math.Max(1, secondsLeft));
                PauseWithCountdown(pause);
                Console.WriteLine();
                breatheIn = !breatheIn;

                // If very close to end, break
                if (sw.Elapsed.TotalSeconds >= DurationSeconds) break;
            }

            sw.Stop();
        }
    }

    // Reflection Activity
    class ReflectionActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
            : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        { }

        protected override void RunActivity()
        {
            // Show a random prompt
            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine();
            Console.WriteLine("Reflect on the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you're ready, we will ask reflection questions. Take a moment to think...");
            PauseWithDots(3);

            Stopwatch sw = Stopwatch.StartNew();

            while (sw.Elapsed.TotalSeconds < DurationSeconds)
            {
                // pick a random question
                string q = _questions[_random.Next(_questions.Count)];
                Console.WriteLine();
                Console.WriteLine($"-> {q}");
                // Pause with spinner for a few seconds (e.g., 6 seconds) or cap by remaining time
                int remaining = DurationSeconds - (int)sw.Elapsed.TotalSeconds;
                int pause = Math.Min(6, Math.Max(1, remaining));
                PauseWithSpinner(pause);
                Console.WriteLine();
            }

            sw.Stop();
        }
    }

    // Listing Activity
    class ListingActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        protected override void RunActivity()
        {
            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine();
            Console.WriteLine("List as many responses as you can for the prompt below:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("You will have a few seconds to think, then begin listing.");
            // Give a short countdown to prepare (e.g., 5 seconds)
            Console.Write("Starting in ");
            PauseWithCountdown(5);
            Console.WriteLine();

            Console.WriteLine("Begin! Type items (press Enter after each). Timer is running...");
            List<string> responses = new List<string>();

            Stopwatch sw = Stopwatch.StartNew();
            while (sw.Elapsed.TotalSeconds < DurationSeconds)
            {
                // Check if console input is available without blocking until timeout
                // Console.ReadLine() is blocking, so we need a way to read with a timeout.
                // We'll do a simple approach: if there is an input ready in the input buffer, read it;
                // otherwise wait a short time and continue until time is up.
                // Unfortunately Console.KeyAvailable only works per key and not per full line if pasted.
                // We'll use a small loop that checks for input: if user types Enter, a line will be ready.

                // Attempt to read a line if available
                if (Console.KeyAvailable)
                {
                    string? line = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        responses.Add(line.Trim());
                    }
                }
                else
                {
                    // Sleep briefly to avoid busy spin and allow time to pass
                    Thread.Sleep(200);
                }
            }
            sw.Stop();

            Console.WriteLine();
            Console.WriteLine($"Time's up! You listed {responses.Count} item(s).");
            if (responses.Count > 0)
            {
                Console.WriteLine("Here are the items you entered:");
                for (int i = 0; i < responses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {responses[i]}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Mindful Activities ===");
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Show session log");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option (1-5): ");

                string? choice = Console.ReadLine();
                Activity? activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        Console.Clear();
                        Activity.PrintSessionLog();
                        Console.WriteLine("Press Enter to return to menu...");
                        Console.ReadLine();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }

                if (activity != null)
                {
                    activity.Start();
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to return to the main menu...");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Goodbye! Take care.");
        }
    }
}
