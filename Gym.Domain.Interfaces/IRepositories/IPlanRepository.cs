using Gym.Domain.Entities;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IPlanRepository : IBaseCrud<PlanEntity, Guid>
    {
        Task<PlanEntity> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null);
    }
}
