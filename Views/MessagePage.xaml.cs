using svendeMobil.ViewModels;

namespace svendeMobil.Views;

public partial class MessagePage : ContentPage
{
	public MessagePage(MessageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}