using Gym.Domain.Entities;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IMetricsRepository : IBaseCrud<MetricsEntity, Guid>
    {
        Task<MetricsEntity> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null);
    }
}
