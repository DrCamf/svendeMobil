using svendeMobil.Handlers;
using svendeMobil.Models;

namespace svendeMobil;

public partial class App : Application
{
    public static UserInfo UserInfo;

    public App()
	{
		

        MainPage = new AppShell();
	}
}
