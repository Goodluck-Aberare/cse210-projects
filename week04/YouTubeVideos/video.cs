using System.Collections.Generic;

namespace Models
{
    public class Video
    {
        public string Title { get; }
        public string Author { get; }
        public int LengthSeconds { get; }

        private List<Comment> comments = new List<Comment>();

        public Video(string title, string author, int lengthSeconds)
        {
            Title = title;
            Author = author;
            LengthSeconds = lengthSeconds;
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return comments.Count;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }
    }
}
