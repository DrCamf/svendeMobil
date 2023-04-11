using svendeMobil.ViewModels;

namespace svendeMobil.Views;

public partial class MessageSendPage : ContentPage
{
	public MessageSendPage(MessageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}