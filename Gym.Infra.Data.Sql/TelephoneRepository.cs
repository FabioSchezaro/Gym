using Dapper;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Infra.Data.Sql
{
    public class TelephoneRepository : BaseCrud<TelephoneEntity, Guid>, ITelephoneRepository
    {
        public Task<List<TelephoneEntity>> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"SELECT * FROM dbo.Telephone WHERE IdPeople = @idPeople";

                return connection.QueryAsync<TelephoneEntity>(sql, new { idPeople }).Result.ToList();
            });
        }
    }
}
