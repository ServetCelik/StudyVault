namespace StudyVault.Application.DTOs
{
    public class SearchNotePreviewDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
        public string Difficulty { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
