using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IMetricsService
    {
        Task<bool> Insert(MetricsEntity metrics);
        Task<bool> Update(MetricsEntity metrics);
        Task<bool> Delete(MetricsEntity metrics);
        Task<List<MetricsEntity>> GetAll();
        Task<MetricsEntity> GetById(Guid id);
    }
}
