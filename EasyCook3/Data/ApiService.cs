using EasyCook3.Models.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Data
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _client = httpClient;
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> PostAsync(string endpoint, dynamic content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _configuration["Settings:URL_API"] + endpoint)
            {
                Content = content
            };

            if (!string.IsNullOrEmpty(TokenManager.Token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenManager.Token);
            }

            return await _client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> GetASync(string endpoint)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _configuration["Settings:URL_API"] + endpoint);
            
            if (!string.IsNullOrEmpty(TokenManager.Token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenManager.Token);
            }
            var url = _configuration["Settings:URL_API"] + endpoint;
            try
            {
                var a = await _client.SendAsync(request);
                Console.WriteLine(a);
                return a;
            }
            catch (Exception ex)
            {
                var b = ex.Message;
                return null;
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint, dynamic content)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, _configuration["Settings:URL_API"] + endpoint)
            {
                Content = content
            };

            if (!string.IsNullOrEmpty(TokenManager.Token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenManager.Token);
            }

            return await _client.SendAsync(request);
        }

        public StringContent? ConvertToContent(dynamic json)
        {
            StringContent content = null;

            var JsonContent = System.Text.Json.JsonSerializer.Serialize(json);
            content = new StringContent(JsonContent, Encoding.UTF8, "application/json");
            return content;
        }

    }
}
