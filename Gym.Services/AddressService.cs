using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressRepository _addressRepository;

        public AddressService(IUnitOfWork unitOfWork, IAddressRepository addressRepository)
        {
            _unitOfWork = unitOfWork;
            _addressRepository = addressRepository;
        }
        public Task<bool> Delete(AddressEntity address)
        {
            return Task.Run(() =>
            {
                return _addressRepository.DeleteAsync(address, _unitOfWork.GetConnection());
            });
        }

        public Task<List<AddressEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _addressRepository.GetAll(_unitOfWork.GetConnection());
            });
        }

        public Task<AddressEntity> GetById(Guid id)
        {
            return Task.Run(() =>
            {
                return _addressRepository.GetById(id, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Insert(AddressEntity address)
        {
            return Task.Run(() =>
            {
                return _addressRepository.InsertAsync(address, _unitOfWork.GetConnection());
            });
        }

        public Task<bool> Update(AddressEntity address)
        {
            return Task.Run(() =>
            {
                return _addressRepository.UpdateAsync(address, _unitOfWork.GetConnection());
            });
        }
    }
}
