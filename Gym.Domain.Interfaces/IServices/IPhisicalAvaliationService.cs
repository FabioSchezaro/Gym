using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IPhisicalAvaliationService
    {
        Task<bool> Insert(PhisicalAvaliationEntity phisicalAvaliation);
        Task<bool> Update(PhisicalAvaliationEntity phisicalAvaliation);
        Task<bool> Delete(PhisicalAvaliationEntity phisicalAvaliation);
        Task<List<PhisicalAvaliationEntity>> GetAll();
        Task<PhisicalAvaliationEntity> GetById(Guid id);
    }
}
