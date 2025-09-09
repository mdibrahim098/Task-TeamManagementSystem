using Microsoft.AspNetCore.Mvc;
using TaskManagementDomain.Entities;
using TaskManagementDomain.Enums;

namespace Task_TeamManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _repo;
        private readonly ICurrentUserService _currentUser;
        public UsersController(IUserRepository repo, ICurrentUserService currentUser)
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
        public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _repo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            CheckAdmin();
            await _repo.AddAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            CheckAdmin();
            if (id != user.Id) return BadRequest();
            await _repo.UpdateAsync(user);
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
