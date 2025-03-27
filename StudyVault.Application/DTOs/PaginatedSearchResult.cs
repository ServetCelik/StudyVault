using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyVault.Application.DTOs
{
    public class PaginatedSearchResult<T>
    {
        public long TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Results { get; set; } = Enumerable.Empty<T>();
    }
}
