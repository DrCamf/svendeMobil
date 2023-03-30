using Newtonsoft.Json;
using svendeMobil.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ThreadNetwork;

namespace svendeMobil.Services
{
    public class MessageApiService : BaseService
    {
        HttpClient _httpClient;
        public string StatusMessage;
        List<UserBasicInfo> _users;

        public async Task<UserBasicInfo> GetUser()
        {
            _users = new List<UserBasicInfo>();
            UserBasicInfo userBasicInfo = null;
            try
            {
                //var response = await _httpClient.GetFromJsonAsync<UserBasicInfo>("/svendetest/api/users" );
                //HttpResponseMessage response = await _httpClient.GetAsync("/svendetest/api/users");

                HttpResponseMessage response = await _httpClient.GetAsync("/svendetest/api/users");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //serBasicInfo = JsonSerializer.Deserialize<UserBasicInfo>(content);
                }

                /*if (!string.IsNullOrEmpty(response.FullName))
                {
                    StatusMessage = "Login Successful";

                    return JsonConvert.DeserializeObject<UserBasicInfo>(await response.  .FullName.ToString());
                }*/
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return userBasicInfo;
        } 
    }
}
