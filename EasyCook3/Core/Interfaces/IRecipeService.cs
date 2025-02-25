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
        Task<RecipeDTO> GetRecipe (int id);
        Task<List<RecipesListDTO>> GetAll(int? order);
        public List<RecipesListDTO> GetRecipesByUser (int userId);
        Task<List<RecipesListDTO>> GetFavsUser();
        Task<List<RecipeDTO>> GetAllInFav();
    }
}
