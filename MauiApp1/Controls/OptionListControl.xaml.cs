using MauiApp1.Models;
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

#if ANDROID
    private async void ViewCell_Tapped(object sender, EventArgs e)
    {
        if (sender is ViewCell viewCell && viewCell.BindingContext is OptionModel selectedItem)
        {
            await Application.Current.MainPage.DisplayAlert("Item Tapped", $"Name: {selectedItem.Name}, Value: {selectedItem.Value}", "OK");

            if (selectedItem.Name == "Notifications")
            {
                await HandleNotificationPermission(selectedItem);
            }
        }
    }

    private async Task HandleNotificationPermission(OptionModel selectedItem)
    {
        bool permissionGranted = await RequestNotificationPermissionAsync();

        if (!permissionGranted)
        {
            bool userNavigatedToSettings = await Application.Current.MainPage.DisplayAlert(
                "Permission Denied",
                "Notification permission is required. Please enable it in the app settings.",
                "Go to Settings",
                "Cancel"
            );

            if (userNavigatedToSettings)
            {
                OpenAppSettings();

                // Delay to give user time to navigate back
                await Task.Delay(2000); // 5 seconds delay, adjust as needed

                // Recheck permission
                permissionGranted = await RequestNotificationPermissionAsync();
            }
        }

        selectedItem.Value = permissionGranted ? "Granted." : "Permission denied.";
    }

    private async Task<bool> RequestNotificationPermissionAsync()
    {
        PermissionStatus status = await Permissions.RequestAsync<NotificationPermission>();
        return status == PermissionStatus.Granted;
    }

    private void OpenAppSettings()
    {
        var context = Android.App.Application.Context;
        var intent = new Intent();
        intent.SetAction(Android.Provider.Settings.ActionApplicationDetailsSettings);
        var uri = Android.Net.Uri.FromParts("package", context.PackageName, null);
        intent.SetData(uri);
        intent.SetFlags(ActivityFlags.NewTask);
        context.StartActivity(intent);
    }

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
