using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class PhisicalAvaliationService : IPhisicalAvaliationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhisicalAvaliationRepository _phisicalAvaliationRepository;
        public PhisicalAvaliationService(IUnitOfWork unitOfWork, IPhisicalAvaliationRepository phisicalAvaliationRepository)
        {
            _unitOfWork = unitOfWork;
            _phisicalAvaliationRepository = phisicalAvaliationRepository;
        }
        public Task<bool> Delete(PhisicalAvaliationEntity phisicalAvaliation)
        {
            return Task.Run(() =>
            {
                return _phisicalAvaliationRepository.Delete(phisicalAvaliation, _unitOfWork.GetConnection());
            });
        }

        public Task<List<PhisicalAvaliationEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _phisicalAvaliationRepository.GetAll(_unitOfWork.GetConnection());
            });
        }

        public Task<PhisicalAvaliationEntity> GetById(Guid id)
        {
            return Task.Run(() =>
            {
                return _phisicalAvaliationRepository.GetById(id, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Insert(PhisicalAvaliationEntity phisicalAvaliation)
        {
            return Task.Run(() =>
            {
                return _phisicalAvaliationRepository.Insert(phisicalAvaliation, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Update(PhisicalAvaliationEntity phisicalAvaliation)
        {
            return Task.Run(() =>
            {
                return _phisicalAvaliationRepository.Update(phisicalAvaliation, _unitOfWork.GetConnection());
            });
        }
    }
}
