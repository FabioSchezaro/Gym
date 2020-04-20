using Gym.Domain.Entities;
using System;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IPeopleRepository : IBaseCrud<PeopleEntity, Guid>
    {
    }
}
