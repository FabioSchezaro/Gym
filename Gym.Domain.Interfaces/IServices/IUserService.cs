using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IUserService
    {
        Task<bool> Insert(UserEntity user);
        Task<bool> Update(UserEntity user);
        Task<bool> Delete(UserEntity user);
        Task<UserEntity> Authenticate(UserEntity user);
        Task<List<UserEntity>> GetAll();
        Task<UserEntity> GetById(Guid id);
    }
}
