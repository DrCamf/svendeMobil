﻿using Newtonsoft.Json;
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


namespace svendeMobil.Services
{
    public class MessageApiService 
    {
        HttpClient _httpClient;
        public string StatusMessage;
        List<UserBasicInfo> _users;
        public MessageApiService()
        {
            var baseAddress = GetBaseAdress();
            _httpClient = new() { BaseAddress = new Uri(baseAddress) };
        }

        private string GetBaseAdress()
        {
#if DEBUG
            return DeviceInfo.Platform == DevicePlatform.Android ? "https://svende.elthoro.dk" : "https://svende.elthoro.dk";
#elif RELEASE
                // published address here
                return "https://svende.elthoro.dk";
#endif
        }

        public async Task<List<UserBasicInfo>> GetUser()
        {
            _users = new List<UserBasicInfo>();
            UserBasicInfo userBasicInfo = null;
            try
            {
                //var response = await _httpClient.GetFromJsonAsync<UserBasicInfo>("/svendetest/api/users" );
                //HttpResponseMessage response = await _httpClient.GetAsync("/svendetest/api/users");

                // HttpResponseMessage response = await _httpClient.GetAsync("/svendetest/api/users");
                var content = await _httpClient.GetAsync("/svendetest/api/users" );
                _users = JsonConvert.DeserializeObject<List<UserBasicInfo>>(await content.Content.ReadAsStringAsync());

                return _users;
                /*if (response.IsSuccessStatusCode)
                {
                    var content = await response.GetStringAsync;
                    //serBasicInfo = JsonSerializer.Deserialize<UserBasicInfo>(content);
                }*/

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
           
        }

        public async Task<UserModel> FindUser(string email)
        {
            UserModel userInfo;
            try
            {
                var content = await _httpClient.GetAsync("/svendetest/api/users/search/" + email);
                userInfo = JsonConvert.DeserializeObject<UserModel>(await content.Content.ReadAsStringAsync());
                return userInfo;
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }


        public async Task<MessageModel> SendMessage(MessageModel messageModel)
        {

            try
            {
                var response = await _httpClient.PostAsJsonAsync("/svendetest/api/message", messageModel);
                if (!string.IsNullOrEmpty(response.Content.ToString()))
                {
                    //StatusMessage = "Login Successful";

                    return JsonConvert.DeserializeObject<MessageModel>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    //StatusMessage = "Access unsuccessful";
                    return null;
                }
            } 
            catch (Exception ex) 
            {
                return new MessageModel("", "");
            }
       

        }

        public async Task<UserMessageModel> SendUserMessage(UserMessageModel userMessageModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/svendetest/api/usermessage", userMessageModel);
                if (!string.IsNullOrEmpty(response.Content.ToString()))
                {
                    //StatusMessage = "Login Successful";

                    return JsonConvert.DeserializeObject<UserMessageModel>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    //StatusMessage = "Access unsuccessful";
                    return null;
                }
            }
            catch (Exception ex)
            {
                return new UserMessageModel();
            }
        }
    }
}
