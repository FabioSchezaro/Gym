using Gym.Domain.Entities;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IUserRepository : IBaseCrud<UserEntity, Guid>
    {
        Task<UserEntity> GetByUserName(string userName, IDbConnection connection, IDbTransaction transaction = null);
        Task<UserEntity> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null);
    }
}
