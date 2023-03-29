using Newtonsoft.Json;
using RestSharp;
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
    public class UserApiService
    {
        HttpClient _httpClient;
        public string StatusMessage;

        public UserApiService()
        {
            var baseAddress = GetBaseAdress();
            _httpClient = new() { BaseAddress = new Uri(baseAddress) };
        }

        private string GetBaseAdress()
        {
#if DEBUG
            return DeviceInfo.Platform == DevicePlatform.Android ? "https://svende.elthoro.dk/svendetest/api" : "https://svende.elthoro.dk/svendetest/api";
#elif RELEASE
                // published address here
                return "https://svende.elthoro.dk/svendetest/api";
#endif
        }

        public async Task<AuthResponseModel> Login(LoginModel loginModel)
        {
            var url = "https://svende.elthoro.dk/svendetest/api/login";
            
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(loginModel.Email + ":" + loginModel.Password));
            using (var client = new RestClient(url))
            {
                var request = new RestRequest(url, Method.Post);
                var body = @"";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    StatusMessage = "Login Successful";
                } else
                {
                    StatusMessage = "no";
                }
            }

            return new AuthResponseModel()
            {
                UserId = "1",
                firstName = "bob",
                lastName = "bob",
                Token = null
            };
            /*    

            try
            {
                var response = await _httpClient.PostAsJsonAsync("/login", loginModel);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Login Successful";

                return JsonConvert.DeserializeObject<AuthResponseModel>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to login successfully.";
                return new AuthResponseModel();
            }*/
        }

        public async Task SetAuthToken()
        {
            var token = await SecureStorage.GetAsync("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }
}
