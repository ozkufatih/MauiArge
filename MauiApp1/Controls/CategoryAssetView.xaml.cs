using MauiApp1.ViewModels;

namespace MauiApp1.Controls;

public partial class CategoryAssetView : ContentView
{
	private CategoryAssetViewModel _viewModel;

    public CategoryAssetView()
	{
		InitializeComponent();

        _viewModel = new CategoryAssetViewModel();
        BindingContext = _viewModel;
    }
}