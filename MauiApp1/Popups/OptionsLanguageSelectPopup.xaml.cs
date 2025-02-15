using CommunityToolkit.Maui.Views;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Popups;

public partial class OptionsLanguageSelectPopup : Popup
{
    private ResourceManagerService _resourceManagerService;
    private OptionsViewModel _viewModel;
    public OptionsLanguageSelectPopup(OptionsViewModel viewModel, ResourceManagerService resourceManagerService)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;

        _resourceManagerService = resourceManagerService;
        InitializeStrings();
    }

    private async void LanguageList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        LanguageList.SelectedItem = null;

        if (e.SelectedItem is LanguageModel languageModel)
        {
            if (Preferences.Get("AppLanguage", "tr") == languageModel.Value)
            {
                Close();
            }

            else if (await ShowWarning(languageModel.Name))
            {
                if (languageModel.Value == "tr")
                {
                    Preferences.Set("AppLanguage", "tr");
                }
                else if (languageModel.Value == "en")
                {
                    Preferences.Set("AppLanguage", "en");
                }
                _resourceManagerService.reloadResources();
                Close();

            }
        }
    }

    private void InitializeStrings()
    {
        PopUpCloseBtn.Text = _resourceManagerService.Resources.GetString("PopupCloseBtn");
        PopUpTitle.Text = _resourceManagerService.Resources.GetString("LanguageListPopupTitle");
    }

    private void PopUpCloseBtn_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private async Task<bool> ShowWarning(string lang)
    {
        string title = _resourceManagerService.Resources.GetString("AreYouSureTitle");
        string message = _resourceManagerService.Resources.GetString("LanguageListPopupRestartMessage");
        message = message.Replace("%%1", lang);
        string button1 = _resourceManagerService.Resources.GetString("MessageOK");
        string button2 = _resourceManagerService.Resources.GetString("MessageCANCEL");

        bool result = await MessageService.ShowMessageAsync(title, message, button1, button2);
        return result;
    }

}