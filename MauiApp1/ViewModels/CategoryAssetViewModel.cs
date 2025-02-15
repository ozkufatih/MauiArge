﻿using MauiApp1.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1.ViewModels
{
    public class CategoryAssetViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CategoryModel> Categories { get; set; }

        public CategoryAssetViewModel()
        {
            Categories = new ObservableCollection<CategoryModel>
            {
                new CategoryModel
                {
                    Name = "Turkish Lira",
                    Assets = new ObservableCollection<AssetModel>
                    {
                        new AssetModel { Name = "Safe", Value = "1.000", ChangeValue = "0", ChangePercentage = "0" },
                        new AssetModel { Name = "Safe", Value = "1.000", ChangeValue = "0", ChangePercentage = "0" }
                    }
                },
                new CategoryModel
                {
                    Name = "Foreign Currency",
                    Assets = new ObservableCollection<AssetModel>
                    {
                        new AssetModel { Name = "Asset 1", Value = "1.837", ChangeValue = "+356", ChangePercentage = "24.1" }
                    }
                },
                new CategoryModel
                {
                    Name = "Crypto Currency",
                    Assets = new ObservableCollection<AssetModel>
                    {
                        new AssetModel { Name = "Asset 1", Value = "1.118", ChangeValue = "+26", ChangePercentage = "2.3" }
                    }
                }
            };

            foreach (var category in Categories)
            {
                category.PropertyChanged += OnCategoryPropertyChanged;
            }
        }

        private void OnCategoryPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CategoryModel.IsExpanded))
            {
                var expandedCategory = sender as CategoryModel;
                if (expandedCategory != null && expandedCategory.IsExpanded)
                {
                    foreach (var category in Categories)
                    {
                        if (category != expandedCategory)
                        {
                            category.IsExpanded = false;
                        }
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
