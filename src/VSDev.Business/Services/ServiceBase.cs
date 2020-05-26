using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Business.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        #region Consults

        public Task<TEntity> GetById(Guid id)
        {
            return _repositoryBase.GetById(id);
        }

        public Task<TEntity> FindAsNoTracking(Guid id)
        {
            return _repositoryBase.FindAsNoTracking(id);
        }

        public Task<List<TEntity>> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repositoryBase.Find(predicate);
        }

        #endregion

        #region Inputs

        public Task Add(TEntity entity)
        {
            return _repositoryBase.Add(entity);
        }

        public Task Update(TEntity entity)
        {
            return _repositoryBase.Update(entity);
        }

        public Task Remove(Guid id)
        {
            return _repositoryBase.Remove(id);
        }

        public Task RemoveInScale(List<TEntity> entities)
        {
            return _repositoryBase.RemoveInScale(entities);
        }

        #endregion

        public Task<int> SaveChanges()
        {
            return _repositoryBase.SaveChanges();
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

    }
}
