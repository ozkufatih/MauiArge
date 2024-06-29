using CommunityToolkit.Maui.Views;
using MauiApp1.Models;
using MauiApp1.Platforms.Android.MauiApp1.Platforms.Android;
using MauiApp1.Popups;
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Controls;

public partial class OptionListControl : ContentView
{
    OptionsViewModel _viewModel;
    private ResourceManagerService _resourceManagerService;

    public OptionListControl()
    {
        InitializeComponent();
        _resourceManagerService = new ResourceManagerService();
        _viewModel = new OptionsViewModel();
        BindingContext = _viewModel;
    }

    private async void ViewCell_Tapped(object sender, EventArgs e)
    {
        if (sender is ViewCell viewCell && viewCell.BindingContext is OptionModel selectedItem)
        {
            if (selectedItem.Name == _resourceManagerService.resourceManager.GetString("OptionsNotificationMenu"))
            {
                await AndroidNotificationService.HandleNotificationPermission(selectedItem);
            }
            else if (selectedItem.Name == _resourceManagerService.resourceManager.GetString("OptionsLanguageMenu")){
                var popup = new OptionsLanguageSelectPopup(_viewModel,_resourceManagerService);
                Application.Current.MainPage.ShowPopup(popup);
            }
        }
    }

    private async void ListView_Loaded(object sender, EventArgs e)
    {
        PermissionStatus status = await Permissions.RequestAsync<NotificationPermission>();

        foreach (var item in listView.ItemsSource)
        {
            if (item is OptionModel option && option.Name == _resourceManagerService.resourceManager.GetString("OptionsNotificationMenu"))
            {
                option.Value = status == PermissionStatus.Granted ? _resourceManagerService.resourceManager.GetString("OptionsNotificationsEnabled") : _resourceManagerService.resourceManager.GetString("OptionsNotificationsDisabled");
            }
        }
    }

}
