using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IRoleService
    {
        Task<List<RoleEntity>> GetAll();
    }
}
