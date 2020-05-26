using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : EntityBase
    {

        #region Consults

        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> FindAsNoTracking(Guid id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Inputs

        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task RemoveInScale(List<TEntity> entities);
        Task<int> SaveChanges();

        #endregion

    }
}
