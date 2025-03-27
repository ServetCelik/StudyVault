using StudyVault.Application.DTOs;
using StudyVault.Domain.Entities;

namespace StudyVault.Application.Interfaces
{
    public interface ISearchService
    {
        Task IndexNoteAsync(StudyNote note);
        Task<IEnumerable<SearchNotePreviewDto>> SearchNotesAsync(
            string? query,
            string? subject = null,
            string? difficulty = null,
            string? tag = null,
            string? authorName = null);
    }
}
