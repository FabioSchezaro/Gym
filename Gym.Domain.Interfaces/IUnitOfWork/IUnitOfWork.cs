using System;
using System.Data;

namespace Gym.Domain.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        bool Commit();
        bool Rollback();
        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
    }
}
