using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FeinesCamp.Services;
using Xamarin.Forms;

namespace FeinesCamp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IDataService DataService { get; }

        bool isBusy;
        string title;

        public BaseViewModel()
        {
            //From IOC container in Xamarin Forms.
            DataService = DependencyService.Get<IDataService>();
        }

        //Gets the caller name automatically.
        public void OnPropertyChange([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value)
                    return;

                isBusy = value;
                OnPropertyChange();
                //IsNotBusyChanged
                OnPropertyChange(nameof(IsNotBusy));
            }
        }

        //To make it easier to get the state when it's not busy.
        public bool IsNotBusy => !IsBusy;

        public string Title
        {
            get => title;
            set
            {
                if (title == value)
                    return;

                title = value;
                OnPropertyChange();

            }
        }
    }
}
