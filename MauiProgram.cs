﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using svendeMobil.Services;
using svendeMobil.ViewModels;
using svendeMobil.Views;

namespace svendeMobil;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		

        builder.Services.AddTransient<UserApiService>();
        builder.Services.AddTransient<MessageApiService>();


        // Views
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<MessagePage>();
        builder.Services.AddSingleton<MessageSendPage>();
        builder.Services.AddSingleton<RegisterPage>();

        // ViewModels
        builder.Services.AddSingleton<LoadingViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<MessageViewModel>();
        builder.Services.AddSingleton<RegisterViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
