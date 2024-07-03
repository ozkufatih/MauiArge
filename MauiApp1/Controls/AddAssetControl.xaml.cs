using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Controls;

public partial class AddAssetControl : ContentView
{
	private ResourceManagerService _resourceManagerService;
	private AssetPageViewModel _viewModel;
	public AddAssetControl(ResourceManagerService resourceManagerService, AssetPageViewModel viewModel)
	{
		InitializeComponent();
		_resourceManagerService = resourceManagerService;
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is CategoryModel tappedCategory)
        {
			CategoryListView.SelectedItem = null;
			MessageService.ShowMessageAsync("Category",$"{tappedCategory.Name}","OK");   
        }
    }
}