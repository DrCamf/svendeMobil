using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System;
using System.Collections.Generic;
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


        [RelayCommand]
        async Task Login()
        {
            if(string.IsNullOrWhiteSpace(useremail) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayLoginError("Invalid User email or password");
            } else
            {
                // call api to attempt a login
                var loginSuccessful = true;
                if(loginSuccessful)
                {
                    //display welcome message

                    //build a menu onthe fly based on the user role

                    // navigate to the apps main page
                }

                await DisplayLoginError("Invalid User email or password");
            }
        }

        public LoginViewModel()
        {
            
        }

        async Task DisplayLoginError(string error)
        {
            await Shell.Current.DisplayAlert("Invalid Attempt",error , "OK");
            password = string.Empty;
        }
    }
}
