#if ANDROID
using Android.Content;
using MauiApp1.Platforms.Android.MauiApp1.Platforms.Android;
#endif

using MauiApp1.Models;

namespace MauiApp1.Services
{
    public class AndroidNotificationService
    {
#if ANDROID
        public static async Task HandleNotificationPermission(OptionModel selectedItem)
        {
            bool permissionGranted = await RequestNotificationPermissionAsync();

            if (!permissionGranted)
            {
                bool userNavigatedToSettings = await MessageService.ShowMessageAsync(
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
#endif
    }
}