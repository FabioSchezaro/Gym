﻿using Gym.Domain.Entities;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IPhisicalAvaliationRepository : IBaseCrud<PhisicalAvaliationEntity, Guid>
    {
        Task<PhisicalAvaliationEntity> GetByIdPeople(Guid idPeople, IDbConnection connection, IDbTransaction transaction = null);
    }
}
