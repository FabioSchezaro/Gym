using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class MetricsService : IMetricsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMetricsRepository _metricsRepository;
        public MetricsService(IUnitOfWork unitOfWork, IMetricsRepository metricsRepository)
        {
            _unitOfWork = unitOfWork;
            _metricsRepository = metricsRepository;
        }
        public Task<bool> Delete(MetricsEntity metrics)
        {
            return Task.Run(() =>
            {
                return _metricsRepository.Delete(metrics, _unitOfWork.GetConnection());
            });
        }

        public Task<List<MetricsEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _metricsRepository.GetAll(_unitOfWork.GetConnection());
            });
        }

        public Task<MetricsEntity> GetById(Guid id)
        {
            return Task.Run(() =>
            {
                return _metricsRepository.GetById(id, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Insert(MetricsEntity metrics)
        {
            return Task.Run(() =>
            {
                return _metricsRepository.Insert(metrics, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Update(MetricsEntity metrics)
        {
            return Task.Run(() =>
            {
                return _metricsRepository.Update(metrics, _unitOfWork.GetConnection());
            });
        }
    }
}
