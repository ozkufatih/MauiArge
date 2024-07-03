using MauiApp1.Pages;
using MauiApp1.Services;

namespace MauiApp1.Controls
{
    public partial class NavigationPanel : ContentView
    {
        public static readonly BindableProperty ContentViewContainerProperty =
            BindableProperty.Create(nameof(ContentViewContainer), typeof(ContentView), typeof(NavigationPanel), null);

        private ResourceManagerService _resourceManagerService;

        public ContentView ContentViewContainer
        {
            get => (ContentView)GetValue(ContentViewContainerProperty);
            set => SetValue(ContentViewContainerProperty, value);
        }

        public NavigationPanel(ResourceManagerService resourceManagerService)
        {
            InitializeComponent();
            _resourceManagerService = resourceManagerService;
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            AddButton(_resourceManagerService.resourceManager.GetString("NavBarAddBtn"), 0, OnAddAssetsClicked);
            AddButton(_resourceManagerService.resourceManager.GetString("NavBarStatusBtn"), 1, (_, __) => { });
            AddButton(_resourceManagerService.resourceManager.GetString("NavBarHomeBtn"), 2, OnHomeClicked);
            AddButton(_resourceManagerService.resourceManager.GetString("NavBarPerformersBtn"), 3, (_, __) => { });
            AddButton(_resourceManagerService.resourceManager.GetString("NavBarOptionsBtn"), 4, OnOptionsClicked);
            // If you add button don't forget to add ColumnDefinition in xaml
            // And don't forget to add handler for button click
        }

        private void AddButton(string text, int gridColumn, EventHandler clickedHandler)
        {
            var button = new Button
            {
                Text = text,
                BackgroundColor = Color.FromArgb("#002c5f"),
                TextColor = Colors.White,
            };
            button.Clicked += clickedHandler;
            Grid.SetColumn(button, gridColumn);
            ((Grid)Content).Children.Add(button);
        }

        private void OnHomeClicked(object? sender, EventArgs e)
        {
            if (ContentViewContainer != null)
            {
                ContentViewContainer.Content = new HomePage(_resourceManagerService);
            }
        }

        private void OnOptionsClicked(object? sender, EventArgs e)
        {
            if (ContentViewContainer != null)
            {
                ContentViewContainer.Content = new OptionsPage(_resourceManagerService);
            }
        }

        private void OnAddAssetsClicked(object? sender, EventArgs e) 
        {
            if (ContentViewContainer != null)
            {
                ContentViewContainer.Content = new AddAssetPage(_resourceManagerService);
            }
        }
    }
}
