using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDomain.Entities;

namespace TaskManagementApplication.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team?> GetByIdAsync(int id);
        Task AddAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(int id);
    }
}
