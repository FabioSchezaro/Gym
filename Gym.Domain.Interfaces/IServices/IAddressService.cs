using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IServices
{
    public interface IAddressService
    {
        Task<bool> Insert(AddressEntity address);
        Task<bool> Update(AddressEntity address);
        Task<bool> Delete(AddressEntity address);
        Task<List<AddressEntity>> GetAll();
        Task<AddressEntity> GetById(Guid id);
    }
}
