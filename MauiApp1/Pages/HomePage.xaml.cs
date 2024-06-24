using MauiApp1.Models;
using MauiApp1.Popups;
using MauiApp1.ViewModels;
using CommunityToolkit.Maui.Views;

namespace MauiApp1.Pages;

public partial class HomePage : ContentView
{
    private DoughnutChartViewModel _viewModel;

    public HomePage()
	{
		InitializeComponent();

        _viewModel = new DoughnutChartViewModel();
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
        var popup = new PortfolioSelectionPopup();
        Application.Current.MainPage.ShowPopup(popup);
    }
}
