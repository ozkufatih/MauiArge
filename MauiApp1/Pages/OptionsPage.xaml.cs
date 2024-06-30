using MauiApp1.Controls;
using MauiApp1.Services;

namespace MauiApp1.Pages;

public partial class OptionsPage : ContentView
{
	private ResourceManagerService _resourceManagerService;
	public OptionsPage(ResourceManagerService resourceManagerService)
	{
		InitializeComponent();
		_resourceManagerService = resourceManagerService;
        var optionListControl = new OptionListControl(_resourceManagerService);
        OptionListControlPlaceholder.Content = optionListControl;
    }
}