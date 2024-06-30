using CommunityToolkit.Maui.Views;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.ViewModels;
using System.Resources;

namespace MauiApp1.Popups;

public partial class PortfolioSelectionPopup : Popup
{
    HomePageViewModel HomePageViewModel;
    ResourceManagerService _resourceManagerService;

    public PortfolioSelectionPopup(HomePageViewModel viewModel, ResourceManagerService resourceManagerService)
    {
        InitializeComponent();
        _resourceManagerService = resourceManagerService;
        InitializeButtons();
        HomePageViewModel = viewModel;
        BindingContext = HomePageViewModel;
    }

    private void InitializeButtons()
    {
        PopUpCloseBtn.Text = _resourceManagerService.resourceManager.GetString("PopupCloseBtn");
        PopUpCreateBtn.Text = _resourceManagerService.resourceManager.GetString("PortfolioListPopupCreateBtn");
        PopUpTitle.Text = _resourceManagerService.resourceManager.GetString("PortfolioListPopupTitle");
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