using Microsoft.AspNetCore.Mvc;
using StudyVault.Application.Interfaces;
using StudyVault.Infrastructure.Db;

namespace StudyVault.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly StudyVaultDbContext _dbContext;

        public SearchController(ISearchService searchService, StudyVaultDbContext dbContext)
        {
            _searchService = searchService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Search(
            [FromQuery] string? q,
            [FromQuery] string? subject,
            [FromQuery] string? difficulty,
            [FromQuery] string? tag,
            [FromQuery] string? authorName)
        {
            var results = await _searchService.SearchNotesAsync(q, subject, difficulty, tag, authorName);
            return Ok(results);
        }
    }
}
