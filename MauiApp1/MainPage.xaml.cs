using MauiApp1.Controls;
using MauiApp1.Pages;
using MauiApp1.Services;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private ResourceManagerService _resourceManagerService;

        public MainPage()
        {
            InitializeComponent();
            _resourceManagerService = new ResourceManagerService();

            ContentViewContainer.Content = new HomePage(_resourceManagerService);

            var navigationPanel = new NavigationPanel(_resourceManagerService)
            {
                ContentViewContainer = ContentViewContainer
            };
            NavigationPanelPlaceholder.Content = navigationPanel;
        }
    }
}
