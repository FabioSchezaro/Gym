using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }
        public Task<List<RoleEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                return _roleRepository.GetAll(_unitOfWork.GetConnection());
            });
        }
    }
}
