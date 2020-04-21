using Gym.Domain.Entities;
using System;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IPlanRepository : IBaseCrud<PlanEntity, Guid>
    {
    }
}
