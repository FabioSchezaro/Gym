using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IFullDataPeopleService
    {
        Task<bool> Insert(FullDataPeopleEntity people);
        Task<bool> Update(FullDataPeopleEntity people);
        Task<bool> Delete(FullDataPeopleEntity people);
        Task<List<FullDataPeopleEntity>> GetAll();
        Task<FullDataPeopleEntity> GetById(Guid id);
    }
}
