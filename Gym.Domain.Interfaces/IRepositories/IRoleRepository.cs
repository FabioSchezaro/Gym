using Gym.Domain.Entities;
using System;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IRoleRepository : IBaseCrud<RoleEntity, Guid>
    {
    }
}
