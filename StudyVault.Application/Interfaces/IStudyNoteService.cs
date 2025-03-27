using StudyVault.Application.DTOs;
using StudyVault.Domain.Entities;

namespace StudyVault.Application.Interfaces
{
    public interface IStudyNoteService
    {
        Task<Guid> CreateAsync(CreateStudyNoteDto dto);

        Task<StudyNote?> GetByIdAsync(Guid id);
        Task BulkCreateAsync(List<StudyNote> notes);
    }
}
