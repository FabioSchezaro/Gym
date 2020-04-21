using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IDueDayService
    {
        Task<bool> Insert(DueDayEntity dueDay);
        Task<bool> Update(DueDayEntity dueDay);
        Task<bool> Delete(DueDayEntity dueDay);
        Task<List<DueDayEntity>> GetAll();
        Task<DueDayEntity> GetById(Guid id);
    }
}
