using EasyCook3.Models.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace EasyCook3.Data
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> LoginAsync(UserLoginDTO user)
        {
            var _client = new HttpClient();
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "User/Login";
            var response = await _client.PostAsync(_configuration["Settings:URL_API"] + url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonObject.Parse(responseContent);
                TokenManager.Token = tokenResponse["token"].ToString();
                return true;
            }

            return false;
        }
    }

}
