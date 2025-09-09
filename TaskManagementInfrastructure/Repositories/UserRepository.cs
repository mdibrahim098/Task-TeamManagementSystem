
using TaskManagementApplication.Interfaces;
using TaskManagementInfrastructure.Data;

namespace TaskManagementInfrastructure.Repositories
{
    public  class UserRepository :IUserRepository
    {

        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db)
        {
            _db = db;
        } 
        public async Task AddAsync(User user) 
        { 
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        { 
            var u = await _db.Users.FindAsync(id); 
            if (u != null) 
            { 
                _db.Users.Remove(u); await _db.SaveChangesAsync();
            } 

        }
        public async Task<IEnumerable<User>> GetAllAsync() => await _db.Users.ToListAsync();
        public async Task<User?> GetByIdAsync(int id) => await _db.Users.FindAsync(id);
        public async Task UpdateAsync(User user) { _db.Users.Update(user); await _db.SaveChangesAsync(); }
    }

}
