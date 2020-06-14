using Dapper;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Infra.Data.Sql
{
    public class PlanRepository : BaseCrud<PlanEntity, Guid>, IPlanRepository
    {
        public Task<PlanEntity> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"select * from dbo.Plan where IdPeople = @idPeople";

                return connection.QueryAsync<PlanEntity>(sql, new { idPeople }).Result.FirstOrDefault();
            });
        }
    }
}
