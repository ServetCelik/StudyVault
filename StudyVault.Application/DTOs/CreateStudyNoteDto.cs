using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyVault.Application.DTOs
{
    public class CreateStudyNoteDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
        public string Difficulty { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
    }
}
