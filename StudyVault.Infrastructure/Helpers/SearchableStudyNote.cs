using Azure.Search.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyVault.Infrastructure.Helpers
{
    using Azure.Search.Documents.Indexes;
    using Azure.Search.Documents.Indexes.Models;

    public class SearchableStudyNote
    {
        [SimpleField(IsKey = true)]
        public string Id { get; set; } = string.Empty;

        [SearchableField]
        public string Title { get; set; } = string.Empty;

        [SearchableField]
        public string Subject { get; set; } = string.Empty;

        [SearchableField(IsFilterable = true, IsFacetable = true)]
        public IList<string> Tags { get; set; } = new List<string>();

        [SearchableField]
        public string Summary { get; set; } = string.Empty;

        [SearchableField]
        public string Content { get; set; } = string.Empty;

        [SearchableField(IsFilterable = true, IsFacetable = true)]
        public string Difficulty { get; set; } = string.Empty;

        [SearchableField(IsFilterable = true, IsFacetable = true)]
        public string AuthorName { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsSortable = true)]
        public DateTime CreatedAt { get; set; }
    }



}
