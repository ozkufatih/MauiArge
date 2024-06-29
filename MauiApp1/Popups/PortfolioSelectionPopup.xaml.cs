using CommunityToolkit.Maui.Views;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Popups;

public partial class PortfolioSelectionPopup : Popup
{
    HomePageViewModel HomePageViewModel;

	public PortfolioSelectionPopup(HomePageViewModel viewModel)
	{
		InitializeComponent();
        HomePageViewModel = viewModel;
        BindingContext = HomePageViewModel;
 
	}

    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Close();
    }

    private void PortfolioList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is PortfolioModel model) 
        { 
        HomePageViewModel.SelectedPortfolio = model.Name;
        }
        Close();
    }


}