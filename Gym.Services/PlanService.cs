using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class PlanService : IPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlanRepository _planRepository;
        public PlanService(IUnitOfWork unitOfWork, IPlanRepository planRepository)
        {
            _unitOfWork = unitOfWork;
            _planRepository = planRepository;
        }
        public Task<bool> Delete(PlanEntity plan)
        {
            return Task.Run(() =>
            {
                return _planRepository.DeleteAsync(plan, _unitOfWork.GetConnection());
            });
        }

        public Task<List<PlanEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _planRepository.GetAll(_unitOfWork.GetConnection());
            });
        }

        public Task<PlanEntity> GetById(Guid id)
        {
            return Task.Run(() =>
            {
                return _planRepository.GetById(id, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Insert(PlanEntity plan)
        {
            return Task.Run(() =>
            {
                return _planRepository.InsertAsync(plan, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Update(PlanEntity plan)
        {
            return Task.Run(() =>
            {
                return _planRepository.UpdateAsync(plan, _unitOfWork.GetConnection());
            });
        }
    }
}
