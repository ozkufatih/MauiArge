using MauiApp1.Pages;

namespace MauiApp1.Controls
{
    public partial class NavigationPanel : ContentView
    {
        public static readonly BindableProperty ContentViewContainerProperty =
            BindableProperty.Create(nameof(ContentViewContainer), typeof(ContentView), typeof(NavigationPanel), null);

        public ContentView ContentViewContainer
        {
            get => (ContentView)GetValue(ContentViewContainerProperty);
            set => SetValue(ContentViewContainerProperty, value);
        }

        public NavigationPanel()
        {
            InitializeComponent();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            AddButton("Add", 0, (_, __) => { });
            AddButton("Status", 1, (_, __) => { });
            AddButton("Home", 2, OnHomeClicked);
            AddButton("Performers", 3, (_, __) => { });
            AddButton("Options", 4, OnOptionsClicked);
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
