using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IPlanService
    {
        Task<bool> Insert(PlanEntity plan);
        Task<bool> Update(PlanEntity plan);
        Task<bool> Delete(PlanEntity plan);
        Task<List<PlanEntity>> GetAll();
        Task<PlanEntity> GetById(Guid id);
    }
}
