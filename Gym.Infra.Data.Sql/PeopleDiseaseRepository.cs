using Dapper;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Gym.Infra.Data.Sql
{
    public class PeopleDiseaseRepository : BaseCrud<PeopleDiseaseEntity, Guid>, IPeopleDiseaseRepository
    {
        public Task<bool> DeleteByIdPeopleAsync(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"DELETE FROM dbo.People_x_Disease WHERE IdPeople = @idPeople";

                return connection.Execute(sql, new { idPeople }, transaction) > 0 ? true : false;
            });
        }
    }
}
