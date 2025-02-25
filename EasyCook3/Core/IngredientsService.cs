using EasyCook3.Models.DTO;
using EasyCook3.Core.Interfaces;
using EasyCook3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core
{
    public class IngredientsService : IIngredientService
    {
        public List<IngredientsDTO> GetIngredients (int recipeId)
        {
            List<IngredientsDTO> list = new List<IngredientsDTO>();

            //foreach(var item in ingredientsList)
            //{
            //    if (item.RecipeId == recipeId)
            //    {
            //        IngredientsDTO ing = new IngredientsDTO
            //        {
            //            IngredientName = item.IngredientName,
            //            Amount = item.Amount,
            //        };

            //        list.Add(ing);
            //    }
            //}

            return list;
        }
    }
}
