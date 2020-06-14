using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IFullDataPeopleService
    {
        Task<bool> InsertAsync(FullDataPeopleEntity people);
        Task<bool> UpdateAsync(FullDataPeopleEntity people);
        Task<bool> DeleteAsync(PeopleEntity people);
        Task<List<FullDataPeopleEntity>> GetAll();
        Task<FullDataPeopleEntity> GetById(Guid id);
    }
}
