using svendeMobil.ViewModels;

namespace svendeMobil.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}