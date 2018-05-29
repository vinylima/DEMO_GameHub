
using System;
using System.Threading.Tasks;

using AutoMapper;

using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.Interfaces.Application;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;
using GameHub.Shared.Kernel.Core.Interfaces.Domain;
using GameHub.Shared.Kernel.Core.Interfaces.Services;
using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHub.Application.AppServices
{
    public abstract class BaseAppService<TViewModel, TModel> : IBaseAppService<TViewModel>
        where TViewModel : IViewModel
        where TModel : IModel
    {
        protected IBaseService<TModel> BaseService;
        protected IMapper Mapper;

        public BaseAppService(IBaseService<TModel> baseService, IMapper mapper)
        {
            this.BaseService = baseService;
            this.Mapper = mapper;
        }
        //Ok
        public virtual IExecutionResult<bool> Save(TViewModel obj)
        {
            var result = new ExecutionResult<bool>();

            var model = this.ConvertViewModelToModel(obj);

            result.Merge(
                this.BaseService.Save(model),
                true
            );

            return result;
        }
        //Ok
        public virtual async Task<IExecutionResult<bool>> SaveAsync(TViewModel obj)
        {
            var result = new ExecutionResult<bool>();
            
            var model = this.ConvertViewModelToModel(obj);

            result.Merge(
                await this.BaseService.SaveAsync(model),
                true
            );

            return result;
        }
        
        public virtual IExecutionResult SaveRange(TViewModel[] array)
        {
            var execResult = new ExecutionResult();

            foreach (var item in array)
            {
                execResult.Merge(
                    this.Save(item)
                );
            }

            return execResult;
        }

        public virtual async Task<IExecutionResult> SaveRangeAsync(TViewModel[] array)
        {
            var execResult = new ExecutionResult();

            foreach (var item in array)
            {
                execResult.Merge(
                    await this.SaveAsync(item)
                );
            }

            return execResult;
        }
        
        public virtual IExecutionResult<bool> Exists(Guid id)
        {
            return this.BaseService.Exists(id);
        }
        //ok
        public virtual IExecutionResult<BaseCollection<TViewModel>> LoadAll()
        {
            var execResult = new ExecutionResult<BaseCollection<TViewModel>>();

            var result = this.BaseService.LoadAll();

            execResult.Merge(result);

            execResult.DefineResult(
                this.ConvertModelToViewModel(result.ReturnResult) as BaseCollection<TViewModel>
            );

            return execResult;
        }
        //ok
        public virtual async Task<IExecutionResult<BaseCollection<TViewModel>>> LoadAllAsync()
        {
            var execResult = new ExecutionResult<BaseCollection<TViewModel>>();

            var result = await this.BaseService.LoadAllAsync();

            execResult.Merge(result);
            
            execResult.DefineResult(
                this.ConvertModelToViewModel(result.ReturnResult) as BaseCollection<TViewModel>
            );

            result.Dispose();
            result = null;

            return execResult;
        }

        public virtual IExecutionResult<bool> Remove(Guid id)
        {
            var execResult = new ExecutionResult<bool>();

            var result = this.BaseService.Remove(id);

            execResult.Merge(result);

            execResult.DefineResult(result.ReturnResult);

            result.Dispose();
            result = null;

            return execResult;
        }

        public virtual async Task<IExecutionResult<bool>> RemoveAsync(Guid id)
        {
            var execResult = new ExecutionResult<bool>();

            var result = await this.BaseService.RemoveAsync(id);

            execResult.Merge(result);

            execResult.DefineResult(result.ReturnResult);

            result.Dispose();
            result = null;

            return execResult;
        }
        
        public virtual IExecutionResult<TViewModel> SearchById(Guid id)
        {
            IExecutionResult<TViewModel> execResult = new ExecutionResult<TViewModel>();

            var result = this.BaseService.SearchById(id);

            execResult.Merge(result);

            execResult.DefineResult(
                this.ConvertModelToViewModel(result.ReturnResult)
            );

            result.Dispose();
            result = null;

            return execResult;
        }

        public virtual async Task<IExecutionResult<TViewModel>> SearchByIdAsync(Guid id)
        {
            IExecutionResult<TViewModel> execResult = new ExecutionResult<TViewModel>();

            var result = await this.BaseService.SearchByIdAsync(id);

            execResult.Merge(result);

            execResult.DefineResult(
                this.ConvertModelToViewModel(result.ReturnResult)
            );

            result.Dispose();
            result = null;

            return execResult;
        }

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }

        /*
        public TViewModel ConvertModelToViewModel(TModel model)
        {
            return this._mapper.Map<TViewModel>(model);
        }

        public TViewModel ConvertViewModelToModel(TViewModel viewModel)
        {
            return this._mapper.Map<TModel>(viewModel);
        }
        */
        internal abstract TViewModel ConvertModelToViewModel(TModel model);
        internal abstract IBaseCollection<TViewModel> ConvertModelToViewModel(IBaseCollection<TModel> model);
        internal abstract TModel ConvertViewModelToModel(TViewModel viewModel);
        internal abstract IBaseCollection<TModel> ConvertViewModelToModel(IBaseCollection<TViewModel> viewModel);

        


        

        

        
    }
}