using Gym.Domain.Entities;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IPeopleDiseaseRepository : IBaseCrud<PeopleDiseaseEntity, Guid>
    {
        Task<bool> DeleteByIdPeopleAsync(Guid idPeople, IDbConnection connection, IDbTransaction transaction);
    }
}
