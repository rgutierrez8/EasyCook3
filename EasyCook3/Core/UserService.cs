using EasyCook3.Core.Interfaces;
using EasyCook3.Data;
using EasyCook3.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core
{
    public class UserService : IUserService
    {
        private readonly ApiService _apiService;

        public UserService(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<UserDTO> GetUser()
        {
            var endpoint = "User/Logged";
            var response = await _apiService.GetASync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<UserDTO>(jsonString);

                return item;
            }

            return null;
        }
        public int GetId(string username)
        {
            //foreach(var user in users)
            //{
            //    if(user.Username == username)
            //    {
            //        return user.Id;
            //    }
            //}

            return -1;
        }

        public async Task<HttpStatusCode> NewUser(NewUserDTO user)
        {
            var endpoint = "User/New";
            var response = await _apiService.PostAsync(endpoint, _apiService.ConvertToContent(user));

          
            return response.StatusCode;
        }
    }
}
