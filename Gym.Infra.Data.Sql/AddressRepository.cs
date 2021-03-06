﻿using Dapper;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Infra.Data.Sql
{
    public class AddressRepository : BaseCrud<AddressEntity, Guid>, IAddressRepository
    {
        public Task<AddressEntity> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"select * from dbo.Address where IdPeople = @idPeople";

                return connection.QueryAsync<AddressEntity>(sql, new { idPeople }).Result.FirstOrDefault();
            });
        }

        public Task<bool> DeleteByIdPeopleAsync(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"DELETE FROM dbo.Address WHERE IdPeople = @idPeople";

                return connection.Execute(sql, new { idPeople }, transaction) > 0 ? true : false;
            });
        }
    }
}
