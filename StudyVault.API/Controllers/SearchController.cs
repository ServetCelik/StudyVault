using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Search([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return BadRequest("Query cannot be empty.");

            var previews = await _searchService.SearchNotesAsync(q);
            return Ok(previews);
        }
    }
}
