using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class TelephoneService : ITelephoneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITelephoneRepository _telephoneRepository;
        public TelephoneService(IUnitOfWork unitOfWork, ITelephoneRepository telephoneRepository)
        {
            _unitOfWork = unitOfWork;
            _telephoneRepository = telephoneRepository;
        }
        public Task<bool> Delete(TelephoneEntity telephone)
        {
            return Task.Run(() =>
            {
                return _telephoneRepository.DeleteAsync(telephone, _unitOfWork.GetConnection());
            });
        }

        public Task<List<TelephoneEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _telephoneRepository.GetAll(_unitOfWork.GetConnection());
            });
        }

        public Task<TelephoneEntity> GetById(Guid id)
        {
            return Task.Run(() =>
            {
                return _telephoneRepository.GetById(id, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Insert(TelephoneEntity telephone)
        {
            return Task.Run(() =>
            {
                return _telephoneRepository.InsertAsync(telephone, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Update(TelephoneEntity telephone)
        {
            return Task.Run(() =>
            {
                return _telephoneRepository.UpdateAsync(telephone, _unitOfWork.GetConnection());
            });
        }
    }
}
