using StudyVault.Application.DTOs;
using StudyVault.Domain.Entities;

namespace StudyVault.Application.Interfaces
{
    public interface ISearchService
    {
        Task IndexNoteAsync(StudyNote note);
        Task<PaginatedSearchResult<SearchNotePreviewDto>> SearchNotesAsync(
            string? query = null,
            string? subject = null,
            string? difficulty = null,
            string? tag = null,
            string? authorName = null,
            int page = 1,
            int pageSize = 10);
    }
}
