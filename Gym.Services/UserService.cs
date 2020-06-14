using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public object TokenService { get; private set; }

        public Task<UserEntity> Authenticate(UserEntity user)
        {
            return Task.Run(() =>
            {
                var entity = _userRepository.GetByUserName(user.UserName, _unitOfWork.GetConnection()).Result;

                user.Password = Token.Security.CryptHelper.EncryptPassword(user.Password);

                if (entity != null)
                    if (entity.Password == user.Password)
                        return entity;

                return null;
            });
        }

        public Task<bool> Delete(UserEntity user)
        {
            return Task.Run(() =>
            {
                return _userRepository.DeleteAsync(user, _unitOfWork.GetConnection());
            });
        }

        public Task<List<UserEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _userRepository.GetAll(_unitOfWork.GetConnection());
            });
        }

        public Task<UserEntity> GetById(Guid id)
        {
            return Task.Run(() =>
            {
                return _userRepository.GetById(id, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Insert(UserEntity user)
        {
            return Task.Run(() =>
            {
                return _userRepository.InsertAsync(user, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Update(UserEntity user)
        {
            return Task.Run(() =>
            {
                return _userRepository.UpdateAsync(user, _unitOfWork.GetConnection());
            });
        }
    }
}
