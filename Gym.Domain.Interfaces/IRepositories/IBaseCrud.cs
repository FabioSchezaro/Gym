using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym.Domain.Interfaces.IRepositories
{
    public interface IBaseCrud<T, V> where T : class
                                     where V : struct
    {
        Task<bool> InsertAsync(T entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(T entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(T entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<T> GetById(V id, IDbConnection connection);
        Task<List<T>> GetAll(IDbConnection connection);
    }
}
