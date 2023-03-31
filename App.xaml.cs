using svendeMobil.Handlers;
using svendeMobil.Models;

namespace svendeMobil;

public partial class App : Application
{
    public static UserInfo UserInfo;
    public static IList<UserBasicInfo> UserBasicInfo;

    public App()
	{
		

        MainPage = new AppShell();
	}
}
