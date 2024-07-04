using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.Models
{
    public class OptionModel : INotifyPropertyChanged
    {
        private string _name;
        private string _value;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        public OptionModel(string name, string value="")
        {
            _name = name;
            _value = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
