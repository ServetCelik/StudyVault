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

        private readonly ISearchService _searchService;

        public StudyNoteService(StudyVaultDbContext context, ISearchService searchService)
        {
            _context = context;
            _searchService = searchService;
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

            await _searchService.IndexNoteAsync(note);
            return note.Id;
        }

        public async Task<StudyNote?> GetByIdAsync(Guid id)
        {
            return await _context.StudyNotes.FindAsync(id);
        }

        public async Task BulkCreateAsync(List<StudyNote> notes)
        {
            await _context.StudyNotes.AddRangeAsync(notes);
            await _context.SaveChangesAsync();

            foreach (var note in notes)
            {
                await _searchService.IndexNoteAsync(note);
            }
        }
    }
}
