
namespace TaskManagementInfrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
         private readonly AppDbContext _db;
    public TeamRepository(AppDbContext db) => _db = db;

    public async Task AddAsync(Team team)
    {
        _db.Teams.Add(team);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var t = await _db.Teams.FindAsync(id);
        if (t != null)
        {
            _db.Teams.Remove(t);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Team>> GetAllAsync() => await _db.Teams.ToListAsync();

    public async Task<Team?> GetByIdAsync(int id) => await _db.Teams.FindAsync(id);

    public async Task UpdateAsync(Team team)
    {
        _db.Teams.Update(team);
        await _db.SaveChangesAsync();
    }

}
}
