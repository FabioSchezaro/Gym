using Dapper;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Infra.Data.Sql
{
    public class ClientRepository : BaseCrud<ClientEntity, Guid>, IClientRepository
    {
        public Task<ClientEntity> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"select c.*, p.*, dd.* from dbo.Client as c
                            inner join dbo.Plans as p on c.IdPlan = p.Id
                            inner join dbo.DueDay as dd on c.IdDueDate = dd.Id
                            where c.IdPeople = @idPeople";

                return connection.QueryAsync<ClientEntity, PlanEntity, DueDayEntity, ClientEntity>(
                    sql,
                    (client, plan, dueDay) =>
                    {
                        client.Plan = plan;
                        client.DueDay = dueDay;

                        return client;
                    },
                    new { idPeople },
                    splitOn: "Id")
                .Result
                .Distinct()
                .FirstOrDefault();
            });
        }

        public Task<bool> DeleteByIdPeopleAsync(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"DELETE FROM dbo.Client WHERE IdPeople = @idPeople";

                return connection.Execute(sql, new { idPeople }, transaction) > 0 ? true : false;
            });
        }

    }
}
