using EasyCook3.Core.Interfaces;
using EasyCook3.Data;
using EasyCook3.Models;
using EasyCook3.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core
{
    public  class CommentService : ICommentService
    {
        private readonly ApiService _apiService;

        public CommentService(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<bool> NewComment(NewCommentDTO comment)
        {
            var endpoint = "Comment/New";
            var response = await _apiService.PostAsync(endpoint, _apiService.ConvertToContent(comment));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
