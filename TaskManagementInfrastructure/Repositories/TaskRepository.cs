namespace TaskManagementInfrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly AppDbContext _db;
        public TaskRepository(AppDbContext db) => _db = db;

        public async Task AddAsync(TaskItem task)
        {
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var t = await _db.Tasks.FindAsync(id);
            if (t != null)
            {
                _db.Tasks.Remove(t);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync() =>
            await _db.Tasks.Include(t => t.AssignedToUser)
                           .Include(t => t.CreatedByUser)
                           .Include(t => t.Team)
                           .ToListAsync();

        public async Task<TaskItem?> GetByIdAsync(int id) =>
            await _db.Tasks.Include(t => t.AssignedToUser)
                           .Include(t => t.CreatedByUser)
                           .Include(t => t.Team)
                           .FirstOrDefaultAsync(t => t.Id == id);

        public async Task UpdateAsync(TaskItem task)
        {
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
        }


        // NEW: Filter/Search implementation
        public async Task<IEnumerable<TaskItem>> GetFilteredAsync(TaskFilterDto filter)
        {
            var query = _db.Tasks.Include(t => t.AssignedToUser)
                                 .Include(t => t.Team)
                                 .AsQueryable();

            if (filter.AssignedToUserId.HasValue)
                query = query.Where(t => t.AssignedToUserId == filter.AssignedToUserId);

            if (filter.TeamId.HasValue)
                query = query.Where(t => t.TeamId == filter.TeamId);

            if (filter.Status.HasValue)
                query = query.Where(t => t.Status == filter.Status);

            if (filter.DueDateFrom.HasValue)
                query = query.Where(t => t.DueDate >= filter.DueDateFrom.Value);

            if (filter.DueDateTo.HasValue)
                query = query.Where(t => t.DueDate <= filter.DueDateTo.Value);


            // Sorting
            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                query = filter.SortDirection.ToLower() == "desc"
                    ? query.OrderByDescendingDynamic(filter.SortBy)
                    : query.OrderByDynamic(filter.SortBy);
            }

            // Pagination
            var skip = (filter.PageNumber - 1) * filter.PageSize;
            query = query.Skip(skip).Take(filter.PageSize);

            return await query.ToListAsync();
        }

    }
}
