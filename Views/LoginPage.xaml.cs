using svendeMobil.ViewModels;

namespace svendeMobil.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}