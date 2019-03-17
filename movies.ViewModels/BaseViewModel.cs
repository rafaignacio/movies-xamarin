using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace movies.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T backStore, T value, [CallerMemberName] string property_name = null)
        {
            if (!Equals(backStore, value))
            {
                backStore = value;
                OnPropertyChanged(property_name);
            }
        }
    }
}
