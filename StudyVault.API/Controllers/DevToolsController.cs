using Microsoft.AspNetCore.Mvc;
using StudyVault.Application.Interfaces;
using StudyVault.Infrastructure.Db;

namespace StudyVault.API.Controllers
{
    [ApiController]
    [Route("api/devtools")]
    public class DevToolsController : ControllerBase
    {
        private readonly IStudyNoteService _studyNoteService;

        public DevToolsController(IStudyNoteService studyNoteService)
        {
            _studyNoteService = studyNoteService;
        }

        [HttpPost("seed")]
        public async Task<IActionResult> Seed([FromQuery] int count = 50)
        {
            var seededNotes = StudyNoteSeeder.SeedStudyNote(count);

            await _studyNoteService.BulkCreateAsync(seededNotes);

            return Ok(new { count = seededNotes.Count });
        }
    }
}
