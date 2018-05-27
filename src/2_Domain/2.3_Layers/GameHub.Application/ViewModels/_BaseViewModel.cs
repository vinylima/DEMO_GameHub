
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using GameHub.Shared.Kernel.Core.Interfaces.Application;

namespace GameHub.Application.ViewModels
{
    public class BaseViewModel<TViewModel> : IViewModel where TViewModel : IViewModel
    {
        public bool IsValid() { return true; }
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            
        }

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            return true;
        }

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }
    }
}