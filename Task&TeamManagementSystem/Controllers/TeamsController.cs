using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementDomain.Entities;

namespace Task_TeamManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _repo;
        private readonly ICurrentUserService _currentUser;

        public TeamsController(ITeamRepository repo, ICurrentUserService currentUser)
        {
            _repo = repo;
            _currentUser = currentUser;
        }

        private void CheckAdmin()
        {
            if (_currentUser.Role != UserRole.Admin)
                throw new UnauthorizedAccessException("Only Admin can perform this action.");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            CheckAdmin();
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CheckAdmin();
            var team = await _repo.GetByIdAsync(id);
            if (team == null) return NotFound();
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Team team)
        {
            CheckAdmin();
            await _repo.AddAsync(team);
            return CreatedAtAction(nameof(Get), new { id = team.Id }, team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Team team)
        {
            CheckAdmin();
            if (id != team.Id) return BadRequest();
            await _repo.UpdateAsync(team);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            CheckAdmin();
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
