namespace StudyVault.Domain.Entities
{
    public class StudyNote
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Summary { get; private set; }
        public string Subject { get; private set; }
        public List<string> Tags { get; private set; }
        public string Difficulty { get; private set; }
        public string AuthorName { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private StudyNote() { } // EF Core needs this

        public StudyNote(string title, string content, string summary, string subject, List<string> tags, string difficulty, string authorName)
        {
            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            Summary = summary;
            Subject = subject;
            Tags = tags ?? new();
            Difficulty = difficulty;
            AuthorName = authorName;
            CreatedAt = DateTime.UtcNow;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Title)) throw new ArgumentException("Title is required");
            if (string.IsNullOrWhiteSpace(Content)) throw new ArgumentException("Content is required");
            if (string.IsNullOrWhiteSpace(Subject)) throw new ArgumentException("Subject is required");
            if (Tags == null || !Tags.Any()) throw new ArgumentException("At least one tag is required");
        }

        public void UpdateContent(string newContent)
        {
            if (string.IsNullOrWhiteSpace(newContent))
                throw new ArgumentException("Content cannot be empty.");

            Content = newContent;
        }

        public void AddTag(string tag)
        {
            if (!Tags.Contains(tag))
                Tags.Add(tag);
        }
    }
}
