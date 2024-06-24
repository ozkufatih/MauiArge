using MauiApp1.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.ViewModels
{
    public class OptionsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<OptionModel> _options { get; set; }
        public ObservableCollection<OptionModel> Options
        {
            get => _options;
            set
            {
                _options = value;
                OnPropertyChanged();
            }
        }

        public OptionsViewModel()
        {
            Options = new ObservableCollection<OptionModel>() {
                new OptionModel("Notifications","Closed"),
                new OptionModel("Language","English"),
                new OptionModel("Currency","TL")
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}