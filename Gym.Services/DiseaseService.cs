using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseaseService(IUnitOfWork unitOfWork, IDiseaseRepository diseaseRepository)
        {
            _unitOfWork = unitOfWork;
            _diseaseRepository = diseaseRepository;
        }
        public Task<bool> Delete(DiseaseEntity disease)
        {
            return Task.Run(() =>
            {
                return _diseaseRepository.Delete(disease, _unitOfWork.GetConnection());
            });
        }

        public Task<List<DiseaseEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _diseaseRepository.GetAll(_unitOfWork.GetConnection());
            });
        }

        public Task<DiseaseEntity> GetById(Guid id)
        {
            return Task.Run(() =>
            {
                return _diseaseRepository.GetById(id, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Insert(DiseaseEntity disease)
        {
            return Task.Run(() =>
            {
                return _diseaseRepository.Insert(disease, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Update(DiseaseEntity disease)
        {
            return Task.Run(() =>
            {
                return _diseaseRepository.Update(disease, _unitOfWork.GetConnection());
            });
        }
    }
}
