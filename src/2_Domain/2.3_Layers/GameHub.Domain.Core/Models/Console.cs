
using GameHub.Shared.Kernel.Core.Interfaces.Domain;
using GameHub.Shared.Kernel.Core.ValueObjects;
using System;

namespace GameHub.Domain.Core.Models
{
    public class Console : IModel
    {
        public Guid ConsoleId { get; private set; }
        public string Name { get; private set; }

        #region Constructors

        public Console()
        {
            this.ConsoleId = Guid.NewGuid();
        }

        public Console(Guid consoleId, string name)
        {
            this.ConsoleId = consoleId;
            this.Name = name;
        }

        #endregion

        public void DefineName(string consoleName)
        { this.Name = consoleName; }

        public ExecutionResult<bool> IsValid()
        {
            var result = new ExecutionResult<bool>();

            result.DefineResult(true);

            return result;
        }

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }

        public Guid GetId()
        {
            return this.ConsoleId;
        }
    }
}