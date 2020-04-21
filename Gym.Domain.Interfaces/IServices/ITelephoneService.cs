using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface ITelephoneService
    {
        Task<bool> Insert(TelephoneEntity telephone);
        Task<bool> Update(TelephoneEntity telephone);
        Task<bool> Delete(TelephoneEntity telephone);
        Task<List<TelephoneEntity>> GetAll();
        Task<TelephoneEntity> GetById(Guid id);
    }
}
