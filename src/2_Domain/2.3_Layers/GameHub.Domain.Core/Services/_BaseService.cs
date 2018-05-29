
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.Interfaces.Domain;
using GameHub.Shared.Kernel.Core.Interfaces.Repositories;
using GameHub.Shared.Kernel.Core.Interfaces.Services;
using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHub.Domain.Core.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : IModel
    {
        protected IBaseRepository<TEntity> Repository { get; private set; }

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            this.Repository = baseRepository;
        }

        public virtual IExecutionResult<bool> Save(TEntity obj)
        {
            var result = this.Repository.Save(obj);

            if (result.Success)
            {
                this.Repository.SaveChanges();

                return result;
            }

            if (result.Errors.Count < 1 && result.SystemErrors.Count < 1)
            {
                result.Errors.Add(
                    new Message("Desculpe, nao foi possível salvar as informacoes e \n" +
                        "nao encontramos indícios do que pode ser. \n\n" +
                        "Fique tranquilo, o Administrador será notificado sobre o ocorrido."
                    )
                );
            }

            // TODO... Eventos de registro de log e notificacao de erros ao desenvolvedor do software

            return result;
        }

        public virtual async Task<IExecutionResult<bool>> SaveAsync(TEntity obj)
        {
            var result = await this.Repository.SaveAsync(obj);

            if (result.Success)
            {
                this.Repository.SaveChanges();

                return result;
            }

            if (result.Errors.Count < 1 && result.SystemErrors.Count < 1)
            {
                result.Errors.Add(
                    new Message("Desculpe, nao foi possível salvar as informacoes e \n" +
                        "nao encontramos indícios do que pode ser. \n\n" +
                        "Fique tranquilo, o Administrador será notificado sobre o ocorrido."
                    )
                );
            }

            // TODO... Eventos de registro de log e notificacao de erros ao desenvolvedor do software

            return result;
        }

        public virtual IExecutionResult SaveRange(TEntity[] array)
        {
            IExecutionResult result = new ExecutionResult();

            foreach(var item in array)
            {
                result.Merge(
                    this.Repository.Save(item)
                );
            }
            
            this.Repository.SaveChanges();

            if (result.Errors.Count < 1 && result.SystemErrors.Count < 1)
            {
                result.Errors.Add(
                    new Message("Desculpe, algumas informacoes podem nao ter sido salvas e \n" +
                        "nao encontramos indícios do que pode ser. \n\n" +
                        "Fique tranquilo, o Administrador será notificado sobre o ocorrido."
                    )
                );
            }

            if (!result.Success)
            {
                // TODO... Eventos de registro de log e notificacao de erros ao desenvolvedor do software
            }

            return result;
        }

        public virtual async Task<IExecutionResult> SaveRangeAsync(TEntity[] array)
        {
            IExecutionResult result = new ExecutionResult();

            foreach (var item in array)
            {
                result.Merge(
                    await this.Repository.SaveAsync(item)
                );
            }
            
            this.Repository.SaveChanges();
            
            if (result.Errors.Count < 1 && result.SystemErrors.Count < 1)
            {
                result.Errors.Add(
                    new Message("Desculpe, algumas informacoes podem nao ter sido salvas e \n" +
                        "nao encontramos indícios do que pode ser. \n\n" +
                        "Fique tranquilo, o Administrador será notificado sobre o ocorrido."
                    )
                );
            }

            if(!result.Success)
            {
                // TODO... Eventos de registro de log e notificacao de erros ao desenvolvedor do software
            }
            
            return result;
        }
        
        public virtual IExecutionResult<bool> Exists(Guid id)
        {
            return this.Repository.Exists(id);
        }
        
        public virtual IExecutionResult<TEntity> SearchById(Guid id)
        {
            return this.Repository.SearchById(id);
        }

        public virtual async Task<IExecutionResult<TEntity>> SearchByIdAsync(Guid id)
        {
            return await this.Repository.SearchByIdAsync(id);
        }

        public virtual IExecutionResult<BaseCollection<TEntity>> LoadAll()
        {
            return this.Repository.GetAll();
        }

        public virtual async Task<IExecutionResult<BaseCollection<TEntity>>> LoadAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }

        public virtual IExecutionResult<bool> Remove(Guid id)
        {
            var result = this.Repository.Remove(id);

            if (result.Success)
                this.Repository.SaveChanges();

            return result;
        }

        public virtual async Task<IExecutionResult<bool>> RemoveAsync(Guid id)
        {
            var result = await this.Repository.RemoveAsync(id);

            if (result.Success)
                this.Repository.SaveChanges();

            return result;
        }
        
        public virtual IExecutionResult<BaseCollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Repository.Find(predicate);
        }

        public virtual async Task<IExecutionResult<BaseCollection<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.Repository.FindAsync(predicate);
        }

        public virtual void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }
    }
}