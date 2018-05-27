
using System;

using GameHub.Shared.Kernel.Core.Interfaces.Collections;
using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHub.Shared.Kernel.Core.Interfaces
{
    public interface IExecutionResult<TResult> : IExecutionResult
    {
        TResult ReturnResult { get; }
        void DefineResult(TResult result);
    }

    public interface IExecutionResult : IDisposable
    {
        IBaseCollection<Message> Errors { get; }
        IBaseCollection<Message> SystemErrors { get; }
        DateTime Time { get; }
        bool Success { get; }

        bool HasErrors();

        IExecutionResult Merge(IExecutionResult result, bool updateTime = false);
    }
}