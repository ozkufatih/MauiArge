using CommunityToolkit.Maui.Views;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Popups;

public partial class PortfolioSelectionPopup : Popup
{
    HomePageViewModel _homePageViewModel;
    ResourceManagerService _resourceManagerService;
    private bool _isCreatePortfolioPopupOpen = false;

    public PortfolioSelectionPopup(HomePageViewModel viewModel, ResourceManagerService resourceManagerService)
    {
        InitializeComponent();
        _resourceManagerService = resourceManagerService;
        InitializeButtons();
        _homePageViewModel = viewModel;
        BindingContext = _homePageViewModel;
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
            _homePageViewModel.SelectedPortfolio = model.Name;
        }
        Close();
    }

    private void OnCreateButtonClicked(object sender, EventArgs e)
    {
        if (_isCreatePortfolioPopupOpen)
            return;

        _isCreatePortfolioPopupOpen = true;

        var popup = new CreatePortfolioPopup(_homePageViewModel, _resourceManagerService);
        popup.Closed += (s, args) => _isCreatePortfolioPopupOpen = false;

        Application.Current.MainPage.ShowPopup(popup);
        Close();
    }


}