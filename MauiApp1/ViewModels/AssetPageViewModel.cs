using MauiApp1.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.ViewModels
{
    public class AssetPageViewModel : INotifyPropertyChanged
    {
        private ResourceManagerService _resourceManagerService;
        private ObservableCollection<CategoryModel> _categories { get; set; }
        public ObservableCollection<CategoryModel> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();

            }
        }

        public AssetPageViewModel(ResourceManagerService resourceManagerService)
        {
            _resourceManagerService = resourceManagerService;
            InitializeAssets();
        }

        private void InitializeAssets()
        {
            Categories = new ObservableCollection<CategoryModel>()
            {
            new CategoryModel(){ Name = _resourceManagerService.resourceManager.GetString("CategoriesTurkishLira") },
            new CategoryModel(){ Name = _resourceManagerService.resourceManager.GetString("CategoriesStock") },
            new CategoryModel(){ Name = _resourceManagerService.resourceManager.GetString("CategoriesCommodity") },
            new CategoryModel(){ Name = _resourceManagerService.resourceManager.GetString("CategoriesForeignCurrency") },
            new CategoryModel(){ Name = _resourceManagerService.resourceManager.GetString("CategoriesFund") },
            new CategoryModel(){ Name = _resourceManagerService.resourceManager.GetString("CategoriesEurobond") },
            new CategoryModel(){ Name = _resourceManagerService.resourceManager.GetString("CategoriesCryptoCurrency") },
            new CategoryModel(){ Name = _resourceManagerService.resourceManager.GetString("CategoriesUSExchanges") },

            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
