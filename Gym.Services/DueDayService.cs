using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class DueDayService : IDueDayService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDueDayRepository _dueDayRepository;
        public DueDayService(IUnitOfWork unitOfWork, IDueDayRepository dueDayRepository)
        {
            _unitOfWork = unitOfWork;
            _dueDayRepository = dueDayRepository;
        }
        public Task<bool> Delete(DueDayEntity dueDay)
        {
            return Task.Run(() =>
            {
                return _dueDayRepository.Delete(dueDay, _unitOfWork.GetConnection());
            });
        }

        public Task<List<DueDayEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _dueDayRepository.GetAll(_unitOfWork.GetConnection());
            });
        }

        public Task<DueDayEntity> GetById(Guid id)
        {
            return Task.Run(() =>
            {
                return _dueDayRepository.GetById(id, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Insert(DueDayEntity dueDay)
        {
            return Task.Run(() =>
            {
                return _dueDayRepository.Insert(dueDay, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Update(DueDayEntity dueDay)
        {
            return Task.Run(() =>
            {
                return _dueDayRepository.Update(dueDay, _unitOfWork.GetConnection());
            });
        }
    }
}
