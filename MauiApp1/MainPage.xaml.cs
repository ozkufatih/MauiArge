using MauiApp1.Pages;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ContentViewContainer.Content = new HomePage();
        }   
    }

}
