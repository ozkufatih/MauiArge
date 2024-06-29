using CommunityToolkit.Maui.Views;
using MauiApp1.Controls;
using MauiApp1.Models;
using MauiApp1.Popups;
using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class HomePage : ContentView
{
    private HomePageViewModel _viewModel;

    public HomePage()
    {
        InitializeComponent();

        _viewModel = new HomePageViewModel();
        _viewModel.SeriesClicked += OnSeriesClicked;
        BindingContext = _viewModel;
    }

    private void OnAddValueClicked(object sender, EventArgs e)
    {
        // Add a new value to the chart
        var newModel = new DoughnutChartModel("GBP", 2);
        _viewModel.AddValue(newModel);
    }

    private void OnPortfolioSelectionClicked(object sender, EventArgs e)
    {
        var popup = new PortfolioSelectionPopup(_viewModel);       
        Application.Current.MainPage.ShowPopup(popup);
    }

    private void OnSeriesClicked(object sender, DoughnutChartModel model)
    {
        var viewModel = (CategoryAssetViewModel)CategoryAssetControl.BindingContext;
        var category = viewModel.Categories.FirstOrDefault(c => c.Name == model.Label);
        if (category != null)
        {
            category.IsExpanded = true;
        }
    }
}
