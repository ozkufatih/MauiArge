using MauiApp1.Pages;
using MauiApp1.Services;

namespace MauiApp1.Controls
{
    public partial class NavigationPanel : ContentView
    {
        public static readonly BindableProperty ContentViewContainerProperty =
            BindableProperty.Create(nameof(ContentViewContainer), typeof(ContentView), typeof(NavigationPanel), null);

        private ResourceManagerService _resourceManagerService;

        private string CurrentPage;

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
            CurrentPage = "HomePage";
        }

        private void InitializeButtons()
        {
            AddButton(_resourceManagerService.Resources.GetString("NavBarAddBtn"), 0, OnAddAssetsClicked);
            AddButton(_resourceManagerService.Resources.GetString("NavBarStatusBtn"), 1, (_, __) => { });
            AddButton(_resourceManagerService.Resources.GetString("NavBarHomeBtn"), 2, OnHomeClicked);
            AddButton(_resourceManagerService.Resources.GetString("NavBarPerformersBtn"), 3, (_, __) => { });
            AddButton(_resourceManagerService.Resources.GetString("NavBarOptionsBtn"), 4, OnOptionsClicked);
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
                if (CurrentPage != "HomePage") 
                {
                    ContentViewContainer.Content = new HomePage(_resourceManagerService);
                    CurrentPage = "HomePage";
                }

            }
        }

        private void OnOptionsClicked(object? sender, EventArgs e)
        {
            if (ContentViewContainer != null)
            {
                if(CurrentPage != "OptionsPage")
                {
                    ContentViewContainer.Content = new OptionsPage(_resourceManagerService);
                    CurrentPage = "OptionsPage";
                }
            }
        }

        private void OnAddAssetsClicked(object? sender, EventArgs e) 
        {
            if (ContentViewContainer != null)
            {
                if (CurrentPage != "AddAssetsPage") { 
                    ContentViewContainer.Content = new AddAssetPage(_resourceManagerService);
                    CurrentPage = "AddAssetsPage";
                }
            }
        }
    }
}
