using StudyVault.Application.DTOs;
using StudyVault.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyVault.Application.Interfaces
{
    public interface IStudyNoteService
    {
        Task<Guid> CreateAsync(CreateStudyNoteDto dto);

        Task<StudyNote?> GetByIdAsync(Guid id);
    }
}
