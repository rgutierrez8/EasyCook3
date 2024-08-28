using EasyCook3.Models;
using EasyCook3.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCook3.Models.DTO;


namespace EasyCook3.Core
{
    public class FavService : IFavService
    {
        public FavService()
        {
        }

        #region LISTA DE FAVORITOS favList

        List<Fav> favList = new List<Fav>()
        {
            new Fav { Id = 1, RecipeId = 7, UserId = 2 },
            new Fav { Id = 2, RecipeId = 19, UserId = 4 },
            new Fav { Id = 3, RecipeId = 35, UserId = 1 },
            new Fav { Id = 4, RecipeId = 22, UserId = 6 },
            new Fav { Id = 5, RecipeId = 14, UserId = 3 },
            new Fav { Id = 6, RecipeId = 28, UserId = 5 },
            new Fav { Id = 7, RecipeId = 8, UserId = 1 },
            new Fav { Id = 8, RecipeId = 30, UserId = 2 },
            new Fav { Id = 9, RecipeId = 3, UserId = 6 },
            new Fav { Id = 10, RecipeId = 25, UserId = 4 },
            new Fav { Id = 11, RecipeId = 17, UserId = 3 },
            new Fav { Id = 12, RecipeId = 10, UserId = 5 },
            new Fav { Id = 13, RecipeId = 33, UserId = 2 },
            new Fav { Id = 14, RecipeId = 21, UserId = 1 },
             new Fav { Id = 15, RecipeId = 6, UserId = 4 },
        };

        #endregion

        public List<Fav> GetFavs(int userID)
        {
            List<Fav> list = new List<Fav>();

            foreach(var item in favList)
            {
                if(item.UserId == userID) list.Add(item);
            }

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
    }
}
