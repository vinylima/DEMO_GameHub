
using System;

using FluentValidation.Results;

using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHub.Domain.Core.Scopes.ExecutionResultScopes
{
    public static class MergeScope
    {
        public static void Merge(this ExecutionResult execResult, ValidationResult result, bool updateDate = false)
        {
            for (int i = 0; i < result.Errors.Count; i++)
            {
                execResult.Errors.Add(
                    new Message(result.Errors[i].ErrorMessage)
                );
            }
            
        }
    }
}