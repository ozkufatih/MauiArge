using MauiApp1.Pages;
using MauiApp1.Services;
using System.Reflection;
using System.Resources;

namespace MauiApp1.Controls
{
    public partial class NavigationPanel : ContentView
    {
        public static readonly BindableProperty ContentViewContainerProperty =
            BindableProperty.Create(nameof(ContentViewContainer), typeof(ContentView), typeof(NavigationPanel), null);

        private ResourceManager _resourceManager;

        public ContentView ContentViewContainer
        {
            get => (ContentView)GetValue(ContentViewContainerProperty);
            set => SetValue(ContentViewContainerProperty, value);
        }

        public NavigationPanel()
        {
            InitializeComponent();
            _resourceManager = new ResourceManagerService().resourceManager;
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            AddButton(_resourceManager.GetString("NavBarAddBtn"), 0, (_, __) => { });
            AddButton(_resourceManager.GetString("NavBarStatusBtn"), 1, (_, __) => { });
            AddButton(_resourceManager.GetString("NavBarHomeBtn"), 2, OnHomeClicked);
            AddButton(_resourceManager.GetString("NavBarPerformersBtn"), 3, (_, __) => { });
            AddButton(_resourceManager.GetString("NavBarOptionsBtn"), 4, OnOptionsClicked);
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
                ContentViewContainer.Content = new HomePage();
            }
        }

        private void OnOptionsClicked(object? sender, EventArgs e)
        {
            if (ContentViewContainer != null)
            {
                ContentViewContainer.Content = new OptionsPage();
            }
        }
    }
}
