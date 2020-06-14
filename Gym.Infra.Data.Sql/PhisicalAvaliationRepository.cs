using Dapper;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Infra.Data.Sql
{
    public class PhisicalAvaliationRepository : BaseCrud<PhisicalAvaliationEntity, Guid>, IPhisicalAvaliationRepository
    {
        public Task<PhisicalAvaliationEntity> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"select * from dbo.PhisicalAvaliation where IdPeople = @idPeople";

                return connection.QueryAsync<PhisicalAvaliationEntity>(sql, new { idPeople }, transaction).Result.FirstOrDefault();
            });
        }

        public Task<bool> DeleteByIdPeopleAsync(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"DELETE FROM dbo.PhisicalAvaliation WHERE IdPeople = @idPeople";

                return connection.Execute(sql, new { idPeople }, transaction) > 0 ? true : false;
            });
        }
    }
}
