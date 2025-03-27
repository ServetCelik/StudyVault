using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using StudyVault.Application.DTOs;
using StudyVault.Application.Interfaces;
using StudyVault.Domain.Entities;
using StudyVault.Infrastructure.Helpers;

namespace StudyVault.Infrastructure.Services
{
    public class SearchService : ISearchService
    {
        private readonly SearchIndexClient _indexClient;
        private readonly SearchClient _searchClient;
        private const string IndexName = "studynotes-index";

        public SearchService(string searchServiceEndpoint, string adminApiKey)
        {
            var endpoint = new Uri(searchServiceEndpoint);
            var credential = new AzureKeyCredential(adminApiKey);

            _indexClient = new SearchIndexClient(endpoint, credential);
            _searchClient = new SearchClient(endpoint, IndexName, credential);
        }

        public async Task IndexNoteAsync(StudyNote note)
        {
            var doc = new SearchableStudyNote
            {
                Id = note.Id.ToString(),
                Title = note.Title,
                Content = note.Content,
                Summary = note.Summary,
                Subject = note.Subject,
                Tags = note.Tags,
                Difficulty = note.Difficulty,
                AuthorName = note.AuthorName,
                CreatedAt = note.CreatedAt
            };

            await _searchClient.MergeOrUploadDocumentsAsync(new[] { doc });
        }

        public async Task<IEnumerable<SearchNotePreviewDto>> SearchNotesAsync(
            string? query,
            string? subject = null,
            string? difficulty = null,
            string? tag = null,
            string? authorName = null)
        {
            var options = new SearchOptions
            {
                IncludeTotalCount = true
            };

            var filters = new List<string>();

            if (!string.IsNullOrWhiteSpace(subject))
                filters.Add($"subject eq '{subject}'");

            if (!string.IsNullOrWhiteSpace(difficulty))
                filters.Add($"difficulty eq '{difficulty}'");

            if (!string.IsNullOrWhiteSpace(tag))
                filters.Add($"tags/any(t: t eq '{tag}')");

            if (!string.IsNullOrWhiteSpace(authorName))
                filters.Add($"authorName eq '{authorName}'");

            if (filters.Any())
                options.Filter = string.Join(" and ", filters);

            var searchTerm = string.IsNullOrWhiteSpace(query) ? "*" : query;

            var results = await _searchClient.SearchAsync<SearchableStudyNote>(searchTerm, options);
            var previews = new List<SearchNotePreviewDto>();

            await foreach (var result in results.Value.GetResultsAsync())
            {
                var doc = result.Document;

                previews.Add(new SearchNotePreviewDto
                {
                    Id = Guid.Parse(doc.Id),
                    Title = doc.Title,
                    Summary = doc.Summary,
                    Subject = doc.Subject,
                    Tags = doc.Tags.ToList(),
                    Difficulty = doc.Difficulty,
                    CreatedAt = doc.CreatedAt
                });
            }

            return previews;
        }
    }
}
