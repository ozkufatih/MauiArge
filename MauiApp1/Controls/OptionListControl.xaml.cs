using MauiApp1.Models;
using MauiApp1.Services;

#if ANDROID
using Android.Content;
using MauiApp1.Platforms.Android.MauiApp1.Platforms.Android;
#endif
using MauiApp1.ViewModels;

namespace MauiApp1.Controls;

public partial class OptionListControl : ContentView
{
    OptionsViewModel _viewModel;

    public OptionListControl()
    {
        InitializeComponent();

        _viewModel = new OptionsViewModel();
        BindingContext = _viewModel;
    }


    private async void ViewCell_Tapped(object sender, EventArgs e)
    {
        if (sender is ViewCell viewCell && viewCell.BindingContext is OptionModel selectedItem)
        {
            if (selectedItem.Name == "Notifications")
            {
#if ANDROID
                await AndroidNotificationService.HandleNotificationPermission(selectedItem);
#endif
            }
        }
    }

#if ANDROID
    private async void ListView_Loaded(object sender, EventArgs e)
    {
        PermissionStatus status = await Permissions.RequestAsync<NotificationPermission>();

        foreach (var item in listView.ItemsSource)
        {
            if (item is OptionModel option && option.Name == "Notifications")
            {
                option.Value = status == PermissionStatus.Granted ? "Granted." : "Permission denied.";
            }
        }
    }
#endif
}
