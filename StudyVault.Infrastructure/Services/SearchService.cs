using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using StudyVault.Application.Interfaces;
using StudyVault.Domain.Entities;
using StudyVault.Infrastructure.Helpers;
using System.Reflection.Emit;

namespace StudyVault.Infrastructure.Services
{
    public class SearchService : ISearchService
    {
        private readonly SearchIndexClient _indexClient;
        private readonly SearchClient _searchClient;
        private const string IndexName = "studynotes-index";

        public SearchService(string searchServiceEndpoint, string adminApiKey)
        {
            Uri serviceEndpoint = new(searchServiceEndpoint);
            AzureKeyCredential credential = new(adminApiKey);

            _indexClient = new SearchIndexClient(serviceEndpoint, credential);
            _searchClient = new SearchClient(serviceEndpoint, IndexName, credential);

            EnsureIndexExists().Wait();
        }

        private async Task EnsureIndexExists()
        {
            var fields = new Azure.Search.Documents.Indexes.FieldBuilder().Build(typeof(SearchableStudyNote));

            var definition = new SearchIndex(IndexName, fields)
            {
                Suggesters = {
                new SearchSuggester("sg", new[] { "title", "subject", "tags" })
            }
            };

            await _indexClient.CreateOrUpdateIndexAsync(definition);
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

        public async Task<IEnumerable<StudyNote>> SearchNotesAsync(string query)
        {
            var options = new SearchOptions
            {
                IncludeTotalCount = true
            };

            var results = await _searchClient.SearchAsync<SearchableStudyNote>(query, options);

            var notes = new List<StudyNote>();

            await foreach (var result in results.Value.GetResultsAsync())
            {
                var doc = result.Document;

                notes.Add(new StudyNote(
                    doc.Title,
                    doc.Content,
                    doc.Summary,
                    doc.Subject,
                    (List<string>)doc.Tags,
                    doc.Difficulty,
                    doc.AuthorName
                ));
            }

            return notes;
        }
    }
}
