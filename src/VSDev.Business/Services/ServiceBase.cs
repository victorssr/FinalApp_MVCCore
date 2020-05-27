using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;
using VSDev.Business.Notifications;

namespace VSDev.Business.Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        private readonly INotificator _notificator;

        protected ServiceBase(IRepositoryBase<TEntity> repositoryBase, INotificator notificator)
        {
            _repositoryBase = repositoryBase;
            _notificator = notificator;
        }

        protected void Notificar(string mensagem)
        {
            _notificator.Handle(new Notification(mensagem));
        }

        protected bool PossuiNotificacao()
        {
            return _notificator.TemNotificacao();
        }

        #region Consults

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _repositoryBase.GetById(id);
        }

        public virtual async Task<TEntity> FindAsNoTracking(Guid id)
        {
            return await _repositoryBase.FindAsNoTracking(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _repositoryBase.GetAll();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repositoryBase.Find(predicate);
        }

        #endregion

        #region Inputs

        public virtual async Task Add(TEntity entity)
        {
            await _repositoryBase.Add(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            await _repositoryBase.Update(entity);
        }

        public virtual async Task Remove(Guid id)
        {
            await _repositoryBase.Remove(id);
        }

        public async Task RemoveInScale(List<TEntity> entities)
        {
            await _repositoryBase.RemoveInScale(entities);
        }

        #endregion

        public async Task<int> SaveChanges()
        {
            return await _repositoryBase.SaveChanges();
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

    }
}
