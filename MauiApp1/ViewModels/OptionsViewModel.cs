using MauiApp1.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.ViewModels
{
    public class OptionsViewModel : INotifyPropertyChanged
    {
        private ResourceManagerService _resourceManagerService;
        private string AppLang;
        private ObservableCollection<OptionModel> _options { get; set; }
        public ObservableCollection<OptionModel> Options
        {
            get => _options;
            set
            {
                _options = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LanguageModel> _languages { get; set; }

        public ObservableCollection<LanguageModel> Languages
        {
            get => _languages;
            set
            {
                _languages = value;
                OnPropertyChanged();
            }

        }

        public OptionsViewModel(ResourceManagerService resourceManagerService)
        {
            _resourceManagerService = resourceManagerService;

            if (Preferences.Get("AppLanguage", "tr") == "tr")
            {
                AppLang = "OptionsLanguagesTR";
            }
            else
            {
                AppLang = "OptionsLanguagesEN";
            }

            InitializeOptions();
        }

        private void InitializeOptions()
        {
            Options = new ObservableCollection<OptionModel>() {
                new OptionModel(_resourceManagerService.Resources.GetString("OptionsNotificationMenu"),_resourceManagerService.Resources.GetString("OptionsNotificationsChecking")),
                new OptionModel(_resourceManagerService.Resources.GetString("OptionsLanguageMenu"),_resourceManagerService.Resources.GetString(AppLang)),
                new OptionModel(_resourceManagerService.Resources.GetString("OptionsCurrencyMenu"),"TL"),
                new OptionModel(_resourceManagerService.Resources.GetString("OptionsSupport")),
                new OptionModel(_resourceManagerService.Resources.GetString("OptionsInvite")),
                new OptionModel(_resourceManagerService.Resources.GetString("OptionsAbout"))

            };

            Languages = new ObservableCollection<LanguageModel>() {
           new LanguageModel(_resourceManagerService.Resources.GetString("OptionsLanguagesTR"),"tr"),
           new LanguageModel(_resourceManagerService.Resources.GetString("OptionsLanguagesEN"),"en"),
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}