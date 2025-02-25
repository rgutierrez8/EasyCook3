using EasyCook3.Core.Interfaces;
using EasyCook3.Core.Helpers;
using EasyCook3.Models.DTO;
using EasyCook3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using EasyCook3.Data;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace EasyCook3.Core
{
    public class RecipeService : IRecipeService
    {
        private readonly IUserService _userService;
        private readonly IIngredientService _ingredientService;
        private readonly IStepService _stepService;
        private readonly ICommentService _commentService;
        private readonly ApiService _apiService;
        public RecipeService(IUserService userService, IIngredientService ingredientService, IStepService stepService, ICommentService commentService, 
                            ApiService apiService)
        {
            _userService = userService;
            _ingredientService = ingredientService;
            _stepService = stepService;
            _commentService = commentService;
            _apiService = apiService;
        }
        public async Task<List<RecipesListDTO>> GetAll(int? order)
        {
            var ListRecipes = new List<RecipesListDTO>();
            var list = new List<RecipesListDTO>();
            var response = await _apiService.GetASync("Recipes/All");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<RecipesListDTO>>(jsonString);
            }

            foreach (var item in list)
            {
                var recipe = new RecipesListDTO()
                {
                    Id = item.Id,
                    Title = item.Title,
                    MainImage = item.MainImage,
                    NeededTime = item.NeededTime + " Min",
                    Username =  item.Username,
                    Likes = item.Likes,
                    dontLike = item.dontLike,
                    TimeToCompare = item.NeededTime
                };

                ListRecipes.Add(recipe);
            }

            if (order == 1) { ListRecipes.Sort((y, x) => x.Likes.CompareTo(y.Likes)); } // ORDEN DE MAS A MENOS LIKES
            if (order == 2) { ListRecipes.Sort((x, y) => x.Likes.CompareTo(y.Likes)); } // ORDEN DE MENOS A MAS LIKES
            if (order == 3) { ListRecipes.Sort((y, x) => x.TimeToCompare.CompareTo(y.TimeToCompare)); } // ORDEN DE MAS A MENOS TIEMPO
            if (order == 4) { ListRecipes.Sort((x, y) => x.TimeToCompare.CompareTo(y.TimeToCompare)); } // ORDEN DE MENOS A MAS TIEMPO

            return ListRecipes;
        }
        public async Task<RecipeDTO> GetRecipe(int id)
        {
            var endpoint = "Recipes/" + id;
            var response = await _apiService.GetASync(endpoint);

            if (response == null)
            {
                // Maneja el error o lanza una excepción
                throw new Exception("No se pudo obtener la receta.");
            }

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<RecipeDTO>(jsonString);

                return item;
            }
            else
            {
                // Manejar la respuesta no exitosa
                throw new Exception("Error al obtener la receta: " + response.StatusCode);
            }


            /*foreach (var item in list)
            {
                if (item.Id == id)
                {
                    //RecipeDTO recipe = new RecipeDTO()
                    //{
                    //    Id = item.Id,
                    //    Title = item.Title,
                    //    Description = item.Description,
                    //    ListIngredients = _ingredientService.GetIngredients(item.Id),
                    //    ListSteps = _stepService.GetSteps(item.Id),
                    //    MainImage = item.MainImage,
                    //    Img2 = item.Img2,
                    //    Img3 = item.Img3,
                    //    Img4 = item.Img4,
                    //    Time = item.Time + " Min",
                    //    Username = "By " + _userService.GetUser(item.UserId).Username,
                    //    Like = item.Like,
                    //    dontLike = item.DontLike,
                    //    CommentList = _commentService.GetComments(item.Id),
                    //};

                    return _helperService.GetRecipeDTO(item);
                }
            }*/

            return null;
        }
        public List<RecipesListDTO> GetRecipesByUser(int userId) {
            List<RecipesListDTO> listRecipes = new List<RecipesListDTO>();

            /*foreach (var item in list)
            {
                if (item.UserId == userId)
                {
                    RecipesListDTO recipe = new RecipesListDTO()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        MainImage = item.MainImage,
                        Time = item.Time + " Min",
                        Username = "By " + _userService.GetUser(item.UserId).Username,
                        Like = item.Like,
                        dontLike = item.DontLike
                    };

                    listRecipes.Add(recipe);
                }

            }*/
            return listRecipes;
        }
        public async Task<List<RecipesListDTO>> GetFavsUser()
        {
            List<RecipesListDTO> ListFav = new List<RecipesListDTO>();

            var endpoint = "Recipes/Favs";
            var response = await _apiService.GetASync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync(); 
                var data = JsonConvert.DeserializeObject<List<RecipesListDTO>>(json);

                return data;
            }

            return ListFav;
        }
        public async Task<List<RecipeDTO>> GetAllInFav()
        {
            var endpoint = "Recipes/Favs/Mobile";
            var response = await _apiService.GetASync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<RecipeDTO>>(json);

                return data;
            }

            return null;
        }
    }
}
