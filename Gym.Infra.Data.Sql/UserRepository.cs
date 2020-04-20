using Dapper;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Infra.Data.Sql
{
    public class UserRepository : BaseCrud<UserEntity, Guid>, IUserRepository
    {
        public Task<UserEntity> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"SELECT * FROM dbo.Users WHERE IdPeople = @idPeople";

                return connection.QueryAsync<UserEntity>(sql, new { idPeople }).Result.FirstOrDefault();
            });
        }

        public Task<UserEntity> GetByUserName(string userName, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                var sql = @"SELECT * FROM dbo.Users WHERE UserName = @userName";

                return connection.QueryAsync<UserEntity>(sql, new { userName }).Result.FirstOrDefault();
            });
        }
    }
}
