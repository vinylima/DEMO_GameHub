using System;
using System.Collections.Generic;
using System.Text;

namespace GameHub.Application.ViewModels
{
    public class ConsoleViewModel : BaseViewModel<ConsoleViewModel>
    {
        private Guid consoleId;
        private string name;

        #region Gets and Sets

        public Guid ConsoleId
        {
            get { return consoleId; }
            set { SetProperty(ref this.consoleId, value); }
        }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref this.name, value); }
        }

        #endregion
    }
}
