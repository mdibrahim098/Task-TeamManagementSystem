using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementDomain.Entities;

namespace Task_TeamManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        private readonly ITeamRepository _repo;
        public TeamsController(ITeamRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _repo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Team team)
        {
            await _repo.AddAsync(team);
            return CreatedAtAction(nameof(Get), new { id = team.Id }, team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Team team)
        {
            if (id != team.Id) return BadRequest();
            await _repo.UpdateAsync(team);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }

    }
}
