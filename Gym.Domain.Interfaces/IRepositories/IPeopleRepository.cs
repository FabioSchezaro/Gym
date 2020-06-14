using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IPeopleRepository : IBaseCrud<PeopleEntity, Guid>
    {
        Task<List<PeopleEntity>> GetByName(string name, IDbConnection connection, IDbTransaction transaction = null);
    }
}
