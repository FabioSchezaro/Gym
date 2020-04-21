using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IDiseaseRepository : IBaseCrud<DiseaseEntity, Guid>
    {
        Task<List<DiseaseEntity>> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null);
    }
}
