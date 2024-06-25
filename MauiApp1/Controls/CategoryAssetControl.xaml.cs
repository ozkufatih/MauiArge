using CommunityToolkit.Maui.Views;
using MauiApp1.ViewModels;

namespace MauiApp1.Controls;

public partial class CategoryAssetControl : ContentView
{
	private CategoryAssetViewModel _viewModel;

	public CategoryAssetControl()
	{
		InitializeComponent();
		_viewModel = new CategoryAssetViewModel();
		BindingContext = _viewModel;
    }
}