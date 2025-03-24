using Microsoft.AspNetCore.Mvc;
using StudyVault.Application.DTOs;
using StudyVault.Application.Interfaces;

namespace StudyVault.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudyNotesController : ControllerBase
    {
        private readonly IStudyNoteService _studyNoteService;

        public StudyNotesController(IStudyNoteService studyNoteService)
        {
            _studyNoteService = studyNoteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudyNoteDto dto)
        {
            var id = await _studyNoteService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var note = await _studyNoteService.GetByIdAsync(id);
            if (note == null)
                return NotFound();

            return Ok(note);
        }

    }
}
