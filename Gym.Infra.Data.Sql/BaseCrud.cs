using Dapper.Contrib.Extensions;
using Gym.Domain.Interfaces.IRepositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Infra.Data.Sql
{
    public class BaseCrud<TEntity, TGuid> : IBaseCrud<TEntity, TGuid> where TEntity : class
                                                                      where TGuid : struct
    {
        public virtual Task<List<TEntity>> GetAll(IDbConnection connection)
        {
            return Task.Run(() =>
            {
                return connection.GetAll<TEntity>().ToList();
            });
        }
        public virtual Task<TEntity> GetById(TGuid id, IDbConnection connection)
        {
            return Task.Run(() =>
            {
                return connection.Get<TEntity>(id);
            });
        }
        public virtual Task<bool> Insert(TEntity entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                try
                {
                    connection.Insert(entity, transaction);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
        public virtual Task<bool> Update(TEntity entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                return connection.Update(entity, transaction);
            });
        }
        public virtual Task<bool> Delete(TEntity entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                return connection.Delete(entity, transaction);
            });
        }
    }
}
