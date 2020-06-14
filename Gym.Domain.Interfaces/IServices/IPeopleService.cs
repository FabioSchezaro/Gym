using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IPeopleService
    {
        Task<bool> Insert(PeopleEntity people);
        Task<bool> Update(PeopleEntity people);
        Task<bool> Delete(PeopleEntity people);
        Task<List<PeopleEntity>> GetAll();
        Task<PeopleEntity> GetById(Guid id);
        Task<List<PeopleEntity>> GetByName(string name);
    }
}
