using MauiApp1.Controls;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MauiApp1.Services
{
    public class ResourceManagerService : INotifyPropertyChanged
    {
       
        private ResourceManager _resourceManager { get; set; }
        public ResourceManager resourceManager
        {
            get => _resourceManager;
            set
            {
                _resourceManager = value;
                OnPropertyChanged();
            }
        }

        public ResourceManagerService()
        {
            InitializeResourceManager();
        }

        private void InitializeResourceManager()
        {
            if (getLanguage() == "tr")
            {
                resourceManager = new ResourceManager("MauiApp1.Resources.Strings.tr.Resources", Assembly.GetExecutingAssembly());
            }
            else if (getLanguage() == "en")
            {
                resourceManager = new ResourceManager("MauiApp1.Resources.Strings.en.Resources", Assembly.GetExecutingAssembly());
            }
        }

        private string getLanguage()
        {
            return Preferences.Get("AppLanguage", "tr");
        }

        public void reloadResources()
        {
            InitializeResourceManager();
            Application.Current.MainPage = new MainPage(); //temporary solution...

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
