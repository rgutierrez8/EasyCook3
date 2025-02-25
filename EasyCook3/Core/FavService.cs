using EasyCook3.Models;
using EasyCook3.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCook3.Models.DTO;
using EasyCook3.Data;


namespace EasyCook3.Core
{
    public class FavService : IFavService
    {
        private readonly ApiService _apiService;
        public FavService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Fav> GetFavs(int userID)
        {
            List<Fav> list = new List<Fav>();

            //foreach(var item in favList)
            //{
            //    if(item.UserId == userID) list.Add(item);
            //}

            return list;
        }
        public Boolean InFavs(int recipeId, int userId)
        {
            var list = GetFavs(userId);

            foreach(var item in list)
            {
                if(item.RecipeId == recipeId)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> NewFav(FavDTO fav)
        {
            var endpoint = "Recipes/Favs/New";
            var content = _apiService.ConvertToContent(fav);

            var response = await _apiService.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteFav(FavDTO fav)
        {
            var endpoint = "Recipes/Favs/Delete";
            var response = await _apiService.DeleteAsync(endpoint, _apiService.ConvertToContent(fav));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
