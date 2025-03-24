using StudyVault.Application.DTOs;
using StudyVault.Application.Interfaces;
using StudyVault.Domain.Entities;
using StudyVault.Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyVault.Infrastructure.Services
{
    public class StudyNoteService : IStudyNoteService
    {
        private readonly StudyVaultDbContext _context;

        public StudyNoteService(StudyVaultDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(CreateStudyNoteDto dto)
        {
            var note = new StudyNote(
                dto.Title,
                dto.Content,
                dto.Summary,
                dto.Subject,
                dto.Tags,
                dto.Difficulty,
                dto.AuthorName
            );

            _context.StudyNotes.Add(note);
            await _context.SaveChangesAsync();
            return note.Id;
        }
    }
}
