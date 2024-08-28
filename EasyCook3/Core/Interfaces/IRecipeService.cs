using EasyCook3.Models.DTO;
using EasyCook3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core.Interfaces
{
    public interface IRecipeService
    {
        public RecipeDTO GetRecipe (int id);
        public List<RecipesListDTO> GetAll(int? order);
        public List<RecipesListDTO> GetRecipesByUser (int userId);
        public List<RecipesListDTO> GetFavsUser(List<Fav> favList);
    }
}
