
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameHub.Shared.Kernel.Core.Interfaces.Application
{
    public interface IViewModel : INotifyPropertyChanged, IDisposable
    {
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null);
        bool IsValid();
    }
}