using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IDiseaseService
    {
        Task<bool> Insert(DiseaseEntity disease);
        Task<bool> Update(DiseaseEntity disease);
        Task<bool> Delete(DiseaseEntity disease);
        Task<List<DiseaseEntity>> GetAll();
        Task<DiseaseEntity> GetById(Guid id);
    }
}
