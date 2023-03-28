namespace svendeMobil.Controls;

public partial class FlyOutHeader : ContentPage
{
	public FlyOutHeader()
	{
		InitializeComponent();
        SetValues();
    }

    private void SetValues()
    {
        if (App.UserInfo != null)
        {
            lblUserName.Text = App.UserInfo.Username;
            lblRole.Text = App.UserInfo.Role;
        }
    }
}