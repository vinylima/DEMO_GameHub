
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using GameHub.Infra.Server.Data.Context;
using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.Interfaces.Domain;
using GameHub.Shared.Kernel.Core.Interfaces.Repositories;
using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHub.Infra.Server.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IModel
    {
        protected GameHub_Context RawDb { get; private set; }
        
        public BaseRepository(GameHub_Context context)
        {
            this.RawDb = context;
        }

        public virtual IExecutionResult<bool> Save(TEntity obj)
        {
            var result = new ExecutionResult<bool>();

            try
            {
                if (!this.Exists(obj.GetId()).ReturnResult)
                    this.RawDb.Set<TEntity>().Add(obj);
                else
                    this.RawDb.Set<TEntity>().Update(obj);
            }
            catch (Exception e)
            {
                /* O correto seria trabalhar melhor a filtragem das mensagens para nao expor informacoes sensíveis 
                 * que possam estar contidas na mensagem de erro que é gerada pelo exception. Mas devido ao tempo, 
                 * nao priorizei este quesito por nao se tratar de um sistema real.
                */

                result.SystemErrors.Add(
                    new Message(e.Message.ToString())
                );
            }

            return result;
        }

        public virtual async Task<IExecutionResult<bool>> SaveAsync(TEntity obj)
        {
            var result = new ExecutionResult<bool>();
            
            try
            {
                if (!this.Exists(obj.GetId()).ReturnResult)
                    await this.RawDb.Set<TEntity>().AddAsync(obj);
                else
                    this.RawDb.Set<TEntity>().Update(obj);
            }
            catch (Exception e)
            {
                /* O correto seria trabalhar melhor a filtragem das mensagens para nao expor informacoes sensíveis 
                 * que possam estar contidas na mensagem de erro que é gerada pelo exception. Mas devido ao tempo, 
                 * nao priorizei este quesito por nao se tratar de um sistema real.
                */

                result.SystemErrors.Add(
                    new Message(e.Message.ToString())
                );
            }

            return result;
        }

        public virtual IExecutionResult SaveRange(TEntity[] array)
        {
            IExecutionResult result = new ExecutionResult();

            foreach(var item in array)
            {
                result.Merge(
                    this.Save(item)
                );
            }

            return result;
        }

        public virtual async Task<IExecutionResult> SaveRangeAsync(TEntity[] array)
        {
            IExecutionResult result = new ExecutionResult();

            foreach (var item in array)
            {
                result.Merge(
                    await this.SaveAsync(item)
                );
            }

            return result;
        }

        public virtual IExecutionResult<bool> Exists(Guid id)
        {
            var result = new ExecutionResult<bool>();

            try
            {
                var entity = this.RawDb.Set<TEntity>()
                    .AsNoTracking()
                    .Where(x => x.GetId() == id)
                    .FirstOrDefault();

                if(entity != null)
                {
                    result.DefineResult(true);

                    entity.Dispose();
                    entity = null;

                    return result;
                }

                result.Errors.Add(
                    new Message("Nao foi possível identificar a existencia das informacoes e \n" + 
                    "o Banco de Dados nao retornou erros.")
                );
            }
            catch(Exception e)
            {
                result.SystemErrors.Add(
                    new Message("Erro ao verificar existencia de objeto: " + e.Message.ToString())
                );
            }

            return result;
        }
        
        public virtual IExecutionResult<BaseCollection<TEntity>> GetAll()
        {
            var result = new ExecutionResult<BaseCollection<TEntity>>();

            try
            {
                result.DefineResult(
                    new BaseCollection<TEntity>(
                        this.RawDb.Set<TEntity>()
                            .AsNoTracking()
                            .ToList()
                    )
                );
            }
            catch(Exception e)
            {
                result.SystemErrors.Add(
                    new Message("Ocorreu um erro ao recuperar a lista de informaoces: " + e.Message.ToString())
                );
            }
            
            return result;
        }

        public virtual async Task<IExecutionResult<BaseCollection<TEntity>>> GetAllAsync()
        {
            var result = new ExecutionResult<BaseCollection<TEntity>>();

            try
            {
                result.DefineResult(
                    new BaseCollection<TEntity>(
                        await this.RawDb.Set<TEntity>()
                            .AsNoTracking()
                            .ToListAsync()
                    )
                );
            }
            catch (Exception e)
            {
                result.SystemErrors.Add(
                    new Message("Ocorreu um erro ao recuperar a lista de informaoces: " + e.Message.ToString())
                );
            }

            return result;
        }

        public virtual IExecutionResult<bool> Remove(Guid id)
        {
            ExecutionResult<bool> execResult = new ExecutionResult<bool>();

            try
            {
                var result = this.RawDb.Set<TEntity>()
                    .Remove(
                        this.SearchById(id).ReturnResult
                    );

                if (result.State.Equals(EntityState.Deleted))
                {
                    execResult.DefineResult(true);

                    return execResult;
                }

                execResult.DefineResult(false);

                execResult.Errors.Add(
                    new Message("As informacoes nao foram removidas, mas o banco de dados nao retornou nenhum erro.")
                );
            }
            catch (Exception e)
            {
                execResult.SystemErrors.Add(
                    new Message("Ocorreu um erro ao tentar remover as informacoes: " + e.Message.ToString())
                );
            }

            return execResult;
        }

        public virtual async Task<IExecutionResult<bool>> RemoveAsync(Guid id)
        {
            ExecutionResult<bool> execResult = new ExecutionResult<bool>();

            try
            {
                var result = this.RawDb.Set<TEntity>()
                    .Remove(
                        this.SearchById(id).ReturnResult
                    );

                if (result.State.Equals(EntityState.Deleted))
                {
                    execResult.DefineResult(true);

                    return execResult;
                }

                execResult.DefineResult(false);

                execResult.Errors.Add(
                    new Message("As informacoes nao foram removidas, mas o banco de dados nao retornou nenhum erro.")
                );
            }
            catch (Exception e)
            {
                execResult.SystemErrors.Add(
                    new Message("Ocorreu um erro ao tentar remover as informacoes: " + e.Message.ToString())
                );
            }

            return execResult;
        }
        
        public virtual IExecutionResult<TEntity> SearchById(Guid id)
        {
            var result = new ExecutionResult<TEntity>();
            TEntity item;

            try
            {
                item = this.RawDb.Set<TEntity>()
                    .AsNoTracking()
                    .Where(x => x.GetId() == id)
                    .FirstOrDefault();

                if (item != null)
                {
                    result.DefineResult(item);

                    item.Dispose();
                    item = null;
                }
            }
            catch(Exception e)
            {
                result.SystemErrors.Add(
                    new Message("Ocorreu um erro ao localizar as informacoes: " + e.Message.ToString())
                );
            }
            
            return result;
        }

        public virtual async Task<IExecutionResult<TEntity>> SearchByIdAsync(Guid id)
        {
            var result = new ExecutionResult<TEntity>();
            TEntity item;

            try
            {
                item = await this.RawDb.Set<TEntity>()
                    .AsNoTracking()
                    .Where(x => x.GetId() == id)
                    .FirstOrDefaultAsync();

                if (item != null)
                {
                    result.DefineResult(item);

                    item.Dispose();
                    item = null;
                }
            }
            catch (Exception e)
            {
                result.SystemErrors.Add(
                    new Message("Ocorreu um erro ao localizar as informacoes: " + e.Message.ToString())
                );
            }

            return result;
        }

        public virtual IExecutionResult<bool> Update(TEntity obj)
        {
            var execResult = new ExecutionResult<bool>();

            try
            {
                var result = this.RawDb.Set<TEntity>().Update(obj);

                if (result.State.Equals(EntityState.Modified))
                {
                    execResult.DefineResult(true);

                    return execResult;
                }
                else
                {
                    execResult.DefineResult(false);

                    execResult.Errors.Add(
                        new Message("Aparentemente as informacoes nao foram atualizadas e \n" + 
                            "o sistema de Banco de Dados nao retornou nenhum erro.")
                    );
                }
            }
            catch (Exception e)
            {
                execResult.SystemErrors.Add(
                    new Message("Ocorreu um erro ao atualizar as informacoes: " + e.Message.ToString())
                );
            }

            return execResult;
        }

        public virtual async Task<IExecutionResult<bool>> UpdateAsync(TEntity obj)
        {
            var execResult = new ExecutionResult<bool>();

            try
            {
                var result = this.RawDb.Set<TEntity>().Update(obj);

                if (result.State.Equals(EntityState.Modified))
                {
                    execResult.DefineResult(true);

                    return execResult;
                }
                else
                {
                    execResult.DefineResult(false);

                    execResult.Errors.Add(
                        new Message("Aparentemente as informacoes nao foram atualizadas e \n" +
                            "o sistema de Banco de Dados nao retornou nenhum erro.")
                    );
                }
            }
            catch (Exception e)
            {
                execResult.SystemErrors.Add(
                    new Message("Ocorreu um erro ao atualizar as informacoes: " + e.Message.ToString())
                );
            }

            return execResult;
        }

        public IExecutionResult<BaseCollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var execResult = new ExecutionResult<BaseCollection<TEntity>>();

            try
            {
                execResult.DefineResult(
                    new BaseCollection<TEntity>(
                        this.RawDb.Set<TEntity>()
                            .AsNoTracking()
                            .Where(predicate)
                    )
                );
            }
            catch (Exception e)
            {
                execResult.SystemErrors.Add(
                    new Message("Erro ao realizar busca avancada: " + e.Message.ToString())
                );
            }

            return execResult;
        }

        public async Task<IExecutionResult<BaseCollection<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var execResult = new ExecutionResult<BaseCollection<TEntity>>();

            try
            {
                execResult.DefineResult(
                    new BaseCollection<TEntity>(
                        this.RawDb.Set<TEntity>()
                            .AsNoTracking()
                            .Where(predicate)
                    )
                );
            }
            catch (Exception e)
            {
                execResult.SystemErrors.Add(
                    new Message("Erro ao realizar busca avancada: " + e.Message.ToString())
                );
            }

            return execResult;
        }

        public virtual IExecutionResult<IQueryable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var result = new ExecutionResult<IQueryable<TEntity>>();

            try
            {
                result.DefineResult(
                    this.RawDb.Set<TEntity>()
                        .AsNoTracking()
                        .Where(predicate)
                );
            }
            catch (Exception e)
            {
                result.SystemErrors.Add(
                    new Message("Ocorreu um erro ao realizar uma busca avancada: " + e.Message.ToString())
                );
            }

            return result;
        }

        public virtual async Task<IExecutionResult<IQueryable<TEntity>>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = new ExecutionResult<IQueryable<TEntity>>();

            try
            {
                result.DefineResult(
                    this.RawDb.Set<TEntity>()
                        .AsNoTracking()
                        .Where(predicate)
                );
            }
            catch (Exception e)
            {
                result.SystemErrors.Add(
                    new Message("Ocorreu um erro ao realizar uma busca avancada: " + e.Message.ToString())
                );
            }

            return result;
        }

        public IExecutionResult<bool> SaveChanges()
        {
            var result = new ExecutionResult<bool>();
            int changes = 0;

            try
            {
                changes = this.RawDb.SaveChanges();

                if (changes > 0)
                    result.DefineResult(true);
                else
                    result.DefineResult(false);
            }
            catch (Exception e)
            {
                result.SystemErrors.Add(
                    new Message("Erro ao salvar informacoes no Banco de Dados: " + e.Message.ToString())
                );

                result.DefineResult(false);
            }

            return result;
        }

        public virtual void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }
    }
}