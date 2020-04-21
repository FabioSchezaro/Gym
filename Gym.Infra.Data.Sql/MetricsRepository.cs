using Dapper;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Infra.Data.Sql
{
    public class MetricsRepository : BaseCrud<MetricsEntity, Guid>, IMetricsRepository
    {
        public Task<MetricsEntity> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction)
        {
            return Task.Run(() =>
            {
                var sql = @"select * from dbo.Metrics where IdPeople = @idPeople";

                return connection.QueryAsync<MetricsEntity>(sql, new { idPeople }, transaction).Result.FirstOrDefault();
            });
        }
    }
}
