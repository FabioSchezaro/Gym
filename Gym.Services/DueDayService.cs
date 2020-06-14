using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return _dueDayRepository.DeleteAsync(dueDay, _unitOfWork.GetConnection());
            });
        }

        public Task<List<DueDayEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _dueDayRepository.GetAll(_unitOfWork.GetConnection()). Result.OrderBy(x => x.Day).ToList();
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
                return _dueDayRepository.InsertAsync(dueDay, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Update(DueDayEntity dueDay)
        {
            return Task.Run(() =>
            {
                return _dueDayRepository.UpdateAsync(dueDay, _unitOfWork.GetConnection());
            });
        }
    }
}
