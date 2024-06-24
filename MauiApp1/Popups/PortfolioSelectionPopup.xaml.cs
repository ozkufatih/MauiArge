using CommunityToolkit.Maui.Views;

namespace MauiApp1.Popups;

public partial class PortfolioSelectionPopup : Popup
{
	public PortfolioSelectionPopup()
	{
		InitializeComponent();
	}

    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Close();
    }
}