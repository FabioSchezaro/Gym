using Gym.Domain.Entities;
using System;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IPeopleDiseaseRepository : IBaseCrud<PeopleDiseaseEntity, Guid>
    {
    }
}
