using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using System;

namespace Gym.Infra.Data.Sql
{
    public class DueDayRepository : BaseCrud<DueDayEntity, Guid>, IDueDayRepository
    {
    }
}
