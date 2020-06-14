using Dapper.Contrib.Extensions;
using Gym.Domain.Interfaces.IRepositories;
using System;
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
        public virtual Task<bool> InsertAsync(TEntity entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                try
                {
                    connection.InsertAsync(entity, transaction);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            });
        }
        public virtual Task<bool> UpdateAsync(TEntity entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                try
                {
                    return connection.UpdateAsync(entity, transaction);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }
        public virtual Task<bool> DeleteAsync(TEntity entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            return Task.Run(() =>
            {
                try
                {
                    return connection.DeleteAsync(entity, transaction);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }
    }
}
