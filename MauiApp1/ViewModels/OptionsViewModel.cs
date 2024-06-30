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
                new OptionModel(_resourceManagerService.resourceManager.GetString("OptionsNotificationMenu"),_resourceManagerService.resourceManager.GetString("OptionsNotificationsChecking")),
                new OptionModel(_resourceManagerService.resourceManager.GetString("OptionsLanguageMenu"),_resourceManagerService.resourceManager.GetString(AppLang)),
                new OptionModel(_resourceManagerService.resourceManager.GetString("OptionsCurrencyMenu"),"TL")
            };

            Languages = new ObservableCollection<LanguageModel>() {
           new LanguageModel(_resourceManagerService.resourceManager.GetString("OptionsLanguagesTR"),"tr"),
           new LanguageModel(_resourceManagerService.resourceManager.GetString("OptionsLanguagesEN"),"en"),
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}