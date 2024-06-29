namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Restrict the APP to use dark theme. Not a good way to be a fix though...
            App.Current.UserAppTheme = AppTheme.Dark;

            MainPage = new AppShell();
        }
    }
}
