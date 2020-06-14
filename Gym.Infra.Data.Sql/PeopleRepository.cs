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
    public class PeopleRepository : BaseCrud<PeopleEntity, Guid>, IPeopleRepository
    {
        public Task<List<PeopleEntity>> GetByName(string name, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"select * from dbo.People WHERE Name Like '%' + @name + '%'";

                return connection.QueryAsync<PeopleEntity>(sql, new { name }, transaction).Result.ToList();
            });
        }
    }
}
