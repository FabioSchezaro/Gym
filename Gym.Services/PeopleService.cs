using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPeopleRepository _peopleRepository;
        public PeopleService(IUnitOfWork unitOfWork, IPeopleRepository peopleRepository)
        {
            _unitOfWork = unitOfWork;
            _peopleRepository = peopleRepository;
        }
        public Task<bool> Delete(PeopleEntity people)
        {
            return Task.Run(() =>
            {
                return _peopleRepository.DeleteAsync(people, _unitOfWork.GetConnection());
            });
        }

        public Task<List<PeopleEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _peopleRepository.GetAll(_unitOfWork.GetConnection());
            });
        }

        public Task<List<PeopleEntity>> GetByName(string name)
        {
            return Task.Run(() =>
            {
                return _peopleRepository.GetByName(name, _unitOfWork.GetConnection());
            });
        }

        public Task<PeopleEntity> GetById(Guid id)
        {
            return Task.Run(() =>
            {
                return _peopleRepository.GetById(id, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Insert(PeopleEntity people)
        {
            return Task.Run(() =>
            {
                return _peopleRepository.InsertAsync(people, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Update(PeopleEntity people)
        {
            return Task.Run(() =>
            {
                return _peopleRepository.UpdateAsync(people, _unitOfWork.GetConnection());
            });
        }
    }
}