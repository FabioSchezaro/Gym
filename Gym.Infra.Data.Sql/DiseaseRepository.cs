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
    public class DiseaseRepository : BaseCrud<DiseaseEntity, Guid>, IDiseaseRepository
    {
        public Task<List<DiseaseEntity>> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction)
        {
            return Task.Run(() =>
            {
                var sql = @"select d.* from dbo.People_x_Disease as pd
                            inner join dbo.Disease as d on pd.IdDisease = d.Id
                            where pd.IdPeople = @idPeople";

                return connection.QueryAsync<DiseaseEntity>(sql, new { idPeople }, transaction).Result.ToList();
            });
        }
    }
}
