using Android.Content;
using MauiApp1.Platforms.Android.MauiApp1.Platforms.Android;
using MauiApp1.Models;

namespace MauiApp1.Services
{
    public class AndroidNotificationService
    {
        private static ResourceManagerService _resourceManagerService;
        public static async Task HandleNotificationPermission(OptionModel selectedItem, ResourceManagerService resourceManagerService)
        {
            _resourceManagerService = resourceManagerService;

            bool permissionGranted = await RequestNotificationPermissionAsync();

            if (!permissionGranted)
            {
                bool userNavigatedToSettings = await MessageService.ShowMessageAsync(
                    _resourceManagerService.resourceManager.GetString("OptionsNotificationsDeniedTitle"),
                    _resourceManagerService.resourceManager.GetString("OptionsNotificationsDeniedMessage"),
                    _resourceManagerService.resourceManager.GetString("OptionsNotificationsGoToSettings"),
                    _resourceManagerService.resourceManager.GetString("MessageCANCEL")
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

            selectedItem.Value = permissionGranted ? _resourceManagerService.resourceManager.GetString("OptionsNotificationsEnabled") : _resourceManagerService.resourceManager.GetString("OptionsNotificationsDisabled");
        }

        private static async Task<bool> RequestNotificationPermissionAsync()
        {
            PermissionStatus status = await Permissions.RequestAsync<NotificationPermission>();
            return status == PermissionStatus.Granted;
        }

        private static void OpenAppSettings()
        {
            var context = Android.App.Application.Context;
            var intent = new Intent();
            intent.SetAction(Android.Provider.Settings.ActionApplicationDetailsSettings);
            var uri = Android.Net.Uri.FromParts("package", context.PackageName, null);
            intent.SetData(uri);
            intent.SetFlags(ActivityFlags.NewTask);
            context.StartActivity(intent);
        }
    }
}