using Newtonsoft.Json;

using svendeMobil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace svendeMobil.Services
{
    public class UserApiService : BaseService
    {
        HttpClient _httpClient;
        public string StatusMessage;

       

        public async Task<AuthResponseModel> Login(LoginModel loginModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/svendetest/api/login", loginModel);
                if (!string.IsNullOrEmpty(response.Content.ToString()))
                {
                    StatusMessage = "Login Successful";

                    return JsonConvert.DeserializeObject<AuthResponseModel>(await response.Content.ReadAsStringAsync());
                } else
                {
                    StatusMessage = "Access unsuccessful";
                    return null;
                }
                //response.EnsureSuccessStatusCode();
                
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to login successfully.";
                return new AuthResponseModel();
            }
        }

        public async Task SetAuthToken()
        {
            var token = await SecureStorage.GetAsync("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }


    }
}
