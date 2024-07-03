using MauiApp1.Controls;
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class AddAssetPage : ContentView
{
	private ResourceManagerService _resourceManagerService;
	private AssetPageViewModel _viewModel;
	public AddAssetPage(ResourceManagerService resourceManagerService)
	{
		InitializeComponent();
		_resourceManagerService = resourceManagerService;
		_viewModel = new AssetPageViewModel(_resourceManagerService);
		AddAssetControlView.Content = new AddAssetControl(_resourceManagerService, _viewModel);
	}
}