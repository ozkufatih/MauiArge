using Android.App;
using CommunityToolkit.Maui.Views;
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Popups;

public partial class CreatePortfolioPopup : Popup
{
	private HomePageViewModel _homePageViewModel;
	private ResourceManagerService _resourceManagerService;
	public CreatePortfolioPopup(HomePageViewModel viewModel, ResourceManagerService resourceManagerService)
	{
		InitializeComponent();
		_homePageViewModel = viewModel;
		_resourceManagerService = resourceManagerService;
        InitializeStrings();
	}
    private void InitializeStrings()
    {
        PopUpCloseBtn.Text = _resourceManagerService.resourceManager.GetString("PopupCloseBtn");
        PopUpCreateBtn.Text = _resourceManagerService.resourceManager.GetString("CreatePortfolioPopupCreateBtn");
        PopUpTitle.Text = _resourceManagerService.resourceManager.GetString("CreatePortfolioPopupTitle");
        PortfolioNameLabel.Text = _resourceManagerService.resourceManager.GetString("CreatePortfolioPopupCreateNameLabel");
        PortfolioNameEntry.Placeholder = _resourceManagerService.resourceManager.GetString("CreatePortfolioPopupCreateEntryPlaceholder");
        PortfolioSettingsLabel.Text = _resourceManagerService.resourceManager.GetString("CreatePortfolioSettingsLabel");
        PortfolioIncludeInConsolidatedLabel.Text = _resourceManagerService.resourceManager.GetString("CreatePortfolioPopupCreateIncludeInConsolidatedLabel");
    }

    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Close();
    }

    private void OnCreateButtonClicked(object sender, EventArgs e) 
    {
        Close();
    }
}