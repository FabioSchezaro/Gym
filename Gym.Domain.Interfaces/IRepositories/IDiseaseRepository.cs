using Gym.Domain.Entities;
using System;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IDiseaseRepository : IBaseCrud<DiseaseEntity, Guid>
    {
    }
}
