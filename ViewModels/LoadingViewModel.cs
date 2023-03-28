using DevExpress.Mvvm;
using Newtonsoft.Json;
using svendeMobil.Models;
using svendeMobil.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svendeMobil.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        public LoadingViewModel()
        {
            CheckUserLoginDetails();
        }

        private async void CheckUserLoginDetails()
        {

            // retrieve token from internal storage

            var token = await SecureStorage.GetAsync("Token");
            

            if (string.IsNullOrEmpty(token) ) 
            {
                await GoToLoginPage();
            }

            //evaluate token and decide if valid
           

            
            /*string userDetailsStr = Preferences.Get(nameof(App.UserDetails), "");

            if (string.IsNullOrWhiteSpace(userDetailsStr))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                // navigate to Login Page
            }
            else
            {
                var userInfo = JsonConvert.DeserializeObject<UserBasicInfo>(userDetailsStr);
                App.UserDetails = userInfo;
                //await AppConstant.AddFlyoutMenusDetails();
            }*/
        }

        private async Task GoToLoginPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async Task GoToMainPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}
