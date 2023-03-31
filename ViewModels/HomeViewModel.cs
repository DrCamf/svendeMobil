using CommunityToolkit.Mvvm.Input;
using svendeMobil.Services;
using svendeMobil.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svendeMobil.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private MessageApiService messageApiService;
        public HomeViewModel()
        {
            this.messageApiService = new MessageApiService();
        }


        [RelayCommand]
        async Task MessageOpen()
        {
            App.UserBasicInfo = await messageApiService.GetUser();
            await Shell.Current.GoToAsync($"//{nameof(MessagePage)}");
        }

        [RelayCommand]
        async Task LogOut()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
