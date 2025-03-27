namespace StudyVault.Infrastructure.Helpers
{
    using Azure.Search.Documents.Indexes;
    using Azure.Search.Documents.Indexes.Models;
    using System.Text.Json.Serialization;

    public class SearchableStudyNote
    {
        [SimpleField(IsKey = true)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [SearchableField]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [SearchableField]
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [SearchableField(IsFilterable = true, IsFacetable = true)]
        [JsonPropertyName("tags")]
        public IList<string> Tags { get; set; }

        [SearchableField]
        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [SearchableField]
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [SearchableField(IsFilterable = true, IsFacetable = true)]
        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }

        [SearchableField(IsFilterable = true, IsFacetable = true)]
        [JsonPropertyName("authorName")]
        public string AuthorName { get; set; }

        [SimpleField(IsFilterable = true, IsSortable = true)]
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
    }



}
