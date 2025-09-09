namespace Task_TeamManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly ITaskRepository _repo;
        private readonly ICurrentUserService _currentUser;
        public TasksController(ITaskRepository repo, ICurrentUserService currentUser)

        {
            _repo = repo;
            _currentUser = currentUser;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _repo.GetAllAsync();

            // Employees see only their assigned tasks
            if (_currentUser.Role == UserRole.Employee)
                tasks = tasks.Where(t => t.AssignedToUserId == _currentUser.UserId);

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null) return NotFound();

            if (_currentUser.Role == UserRole.Employee && task.AssignedToUserId != _currentUser.UserId)
                return Unauthorized("You can view only your assigned tasks.");

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskItem task)
        {
            if (_currentUser.Role != UserRole.Manager && _currentUser.Role != UserRole.Admin)
                return Unauthorized("Only Manager or Admin can create tasks.");

            task.CreatedByUserId = _currentUser.UserId;
            await _repo.AddAsync(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskItem task)
        {
            var existingTask = await _repo.GetByIdAsync(id);
            if (existingTask == null) return NotFound();

            if (_currentUser.Role == UserRole.Employee)
                return Unauthorized("Employees cannot update this task.");

            await _repo.UpdateAsync(task);
            return NoContent();
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] TasksStatus status)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null) return NotFound();

            // Employee can update only their assigned tasks
            if (_currentUser.Role == UserRole.Employee && task.AssignedToUserId != _currentUser.UserId)
                return Unauthorized("You can update only your assigned tasks.");

            task.Status = status;
            await _repo.UpdateAsync(task);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] TaskFilterDto filter)
        {
            var tasks = await _repo.GetFilteredAsync(filter);

            if (_currentUser.Role == UserRole.Employee)
                tasks = tasks.Where(t => t.AssignedToUserId == _currentUser.UserId);

            return Ok(tasks);
        }

    }
}
