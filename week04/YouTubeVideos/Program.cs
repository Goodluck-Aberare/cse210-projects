using System;
using System.Collections.Generic;
using Models;

class Program
{
    static void Main(string[] args)
    {
        // Create video list
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video("How to Cook Jollof Rice", "Chef Anita", 540);
        v1.AddComment(new Comment("Mike", "This recipe is amazing!"));
        v1.AddComment(new Comment("Sarah", "Trying this tonight."));
        v1.AddComment(new Comment("John", "Best jollof tutorial online."));
        videos.Add(v1);

        // Video 2
        Video v2 = new Video("Learn C# in 10 Minutes", "Tech Guru", 600);
        v2.AddComment(new Comment("Paul", "Very helpful!"));
        v2.AddComment(new Comment("Mary", "I love how simple this is."));
        v2.AddComment(new Comment("Leo", "Thanks for the explanations."));
        videos.Add(v2);

        // Video 3
        Video v3 = new Video("Traveling Lagos City", "WanderWorld", 720);
        v3.AddComment(new Comment("Ada", "Lagos is so beautiful!"));
        v3.AddComment(new Comment("Sam", "I want to visit someday."));
        v3.AddComment(new Comment("Kemi", "Nice video!"));
        videos.Add(v3);

        // Display each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }

            Console.WriteLine("----------------------------------------");
        }
    }
}
