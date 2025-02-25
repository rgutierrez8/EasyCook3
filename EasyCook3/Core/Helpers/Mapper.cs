using EasyCook3.Data;
using EasyCook3.Models;
using EasyCook3.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core.Helpers
{
    public interface IMapper
    {
        List<RecipesListDTO> MapRecipeToRecipesListDTO(List<Recipe> recipes);
        Task<RecipeDTO> MapRecipeToRecipeDTO(Recipe recipe);
        List<IngredientsDTO> MapIngredientToIngredientDTO(List<Ingredient> ingredients);
        List<StepDTO> MapStepToStepDTO(List<Step> steps);
        List<CommentDTO> MapCommentToCommentDTO(List<Comment> comment);
    }

    public class Mapper : IMapper
    {
        private readonly MySQLiService _mydb;

        public Mapper(MySQLiService mydb)
        {
            _mydb = mydb;
        }
        public List<RecipesListDTO> MapRecipeToRecipesListDTO(List<Recipe> recipes)
        {
            List<RecipesListDTO> listDTO = new List<RecipesListDTO>();

            if(recipes != null)
            {
                foreach (Recipe recipe in recipes)
                {
                    RecipesListDTO recipeDTO = new RecipesListDTO()
                    {
                        Id = recipe.Id,
                        Title = recipe.Title,
                        MainImage = recipe.MainImage,
                        NeededTime = recipe.NeededTime + " min",
                        Username = recipe.Username,
                        Likes = recipe.Like,
                        dontLike = recipe.DontLike,
                        TimeToCompare = recipe.NeededTime
                    };
                    listDTO.Add(recipeDTO);
                }
            }

            return listDTO;
        }
        public async Task<RecipeDTO> MapRecipeToRecipeDTO(Recipe recipe)
        {
            RecipeDTO recipeDTO = new RecipeDTO()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Describe = recipe.Descripe,
                ListIngredients = MapIngredientToIngredientDTO(await _mydb.GetIngredientAsync(recipe.Id)),
                ListSteps = MapStepToStepDTO(await _mydb.GetStepsAsync(recipe.Id)),
                MainImage = recipe.MainImage,
                Img2 = recipe.Img2,
                Img3 = recipe.Img3,
                Img4 = recipe.Img4,
                NeededTime = recipe.NeededTime,
                Username = recipe.Username,
                Like = recipe.Like,
                dontLike = recipe.DontLike,
                CommentList = MapCommentToCommentDTO(await _mydb.GetCommentAsync(recipe.Id)),
                InFav = true
            };

            return recipeDTO;
        }
        public List<IngredientsDTO> MapIngredientToIngredientDTO(List<Ingredient> ingredients)
        {
            List<IngredientsDTO> list = new List<IngredientsDTO>();

            foreach(Ingredient ingredient in ingredients)
            {
                IngredientsDTO ing = new IngredientsDTO()
                {
                    Amount = ingredient.Amount,
                    IngredientName = ingredient.IngredientName
                };
                list.Add(ing);
            }

            return list;
        }
        public List<StepDTO> MapStepToStepDTO(List<Step> steps)
        {
            List<StepDTO> list = new List<StepDTO>();

            foreach(Step step in steps)
            {
                StepDTO stepDTO = new StepDTO()
                {
                    NumberStep = step.NumberStep,
                    Describe = step.Description
                };
                list.Add(stepDTO);
            }

            return list;
        }
        public List<CommentDTO> MapCommentToCommentDTO(List<Comment> comment) {
            List<CommentDTO> list = new List<CommentDTO>();

            foreach (Comment commentItem in comment)
            {
                CommentDTO commentDTO = new CommentDTO()
                {
                    Username = commentItem.Username,
                    DatePublish = commentItem.Date,
                    Describe = commentItem.Description
                };

                list.Add(commentDTO);   
            }

            return list;
        }

    }
}
