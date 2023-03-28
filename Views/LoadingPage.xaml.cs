using svendeMobil.ViewModels;

namespace svendeMobil.Views;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }

    
}