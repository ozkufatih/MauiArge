using Android.Content;
using CommunityToolkit.Maui.Views;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.ViewModels;
using System.Resources;

namespace MauiApp1.Popups;

public partial class OptionsLanguageSelectPopup : Popup
{
    private ResourceManagerService _resourceManagerService;
    private OptionsViewModel _viewModel;
    public OptionsLanguageSelectPopup(OptionsViewModel viewModel,ResourceManagerService resourceManagerService)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;

        _resourceManagerService = resourceManagerService;
        InitializeButtons();
    }

    private void LanguageList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is LanguageModel languageModel)
        {
            if (languageModel.Value == "tr")
            {
                Preferences.Set("AppLanguage", "tr");
            }
            else if (languageModel.Value == "en")
            {
                Preferences.Set("AppLanguage", "en");
            }
        }
        _resourceManagerService.reloadResources();
        Close();
        
    }

    private void InitializeButtons()
    {
        PopUpCloseBtn.Text = _resourceManagerService.resourceManager.GetString("LanguageListPopupCloseBtn");
        PopUpTitle.Text = _resourceManagerService.resourceManager.GetString("LanguageListPopupTitle");
    }

    private void PopUpCloseBtn_Clicked(object sender, EventArgs e)
    {
        Close();
    }

}