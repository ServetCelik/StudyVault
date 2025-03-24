using StudyVault.Application.DTOs;
using StudyVault.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyVault.Application.Interfaces
{
    public interface ISearchService
    {
        Task IndexNoteAsync(StudyNote note);
        Task<IEnumerable<SearchNotePreviewDto>> SearchNotesAsync(string query);
    }
}
