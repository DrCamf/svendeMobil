using svendeMobil.ViewModels;

namespace svendeMobil.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}