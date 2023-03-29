using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using svendeMobil.Models;
using svendeMobil.Services;
using svendeMobil.Views;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace svendeMobil.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string useremail;

        [ObservableProperty]
        private string password;
       
        private UserApiService userApiService;

        public LoginViewModel(UserApiService userApiService)
        {
            this.userApiService = userApiService;
        }

        [RelayCommand]
        async Task Login()
        {
            if(string.IsNullOrWhiteSpace(useremail) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayLoginMessage("Invalid Login Attempt");
            } else
            {
                // call api to attempt a login
                var loginModel = new LoginModel(useremail, password);

                var response = await userApiService.Login(loginModel);

                //display welcome message
                await DisplayLoginMessage(userApiService.StatusMessage);
               

                if(!string.IsNullOrEmpty(response.Token))
                {
                    // Store token in secure storage
                    await SecureStorage.SetAsync("Token", response.Token);


                    //build a menu onthe fly based on the user role
                    var jsonToken = new JwtSecurityTokenHandler().ReadToken(response.Token) as JwtSecurityToken;
                    //var role = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(JsonClaimValueTypes.Role))?.Value;
                    var role = "user";
                    var userInfo = new UserInfo()
                    {
                        Username = useremail,
                        Role = role
                    };

                    /*if(Preferences.ContainsKey(nameof(UserInfo)))
                    {
                        Preferences.Remove(nameof(UserInfo));
                    }*/

                    App.UserInfo = userInfo; 

                    // navigate to the apps main page
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                } else
                {
                    await DisplayLoginMessage("Invalid Login Attempt");
                }

                
            }
        }


        async Task DisplayLoginMessage(string message)
        {
            await Shell.Current.DisplayAlert("Login Attempt",message , "OK");
            password = string.Empty;
        }
    }
}
