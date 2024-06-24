namespace MauiApp1.Services
{
    public class MessageService
    {
        private static readonly Page _page = Application.Current.MainPage;

        public static async Task ShowMessageAsync(string title, string message, string button1)
        {
            await _page.DisplayAlert(title, message, button1);
            return; 
        }
        public static async Task<bool> ShowMessageAsync(string title, string message, string button1, string button2)
        {
            return await _page.DisplayAlert(title, message, button1, button2);
        }
    }
}
