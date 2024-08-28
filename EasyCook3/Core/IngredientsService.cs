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
        #region LISTA DE INGREDIENTES

        List<Ingredient> ingredientsList = new List<Ingredient>()
        {
            new Ingredient { Id = 1, RecipeId = 1, IngredientName = "Pasta", Amount = "250g" },
            new Ingredient { Id = 2, RecipeId = 1, IngredientName = "Panceta", Amount = "150g" },
            new Ingredient { Id = 3, RecipeId = 1, IngredientName = "Queso parmesano", Amount = "50g" },
            new Ingredient { Id = 4, RecipeId = 1, IngredientName = "Huevo", Amount = "2" },
            new Ingredient { Id = 5, RecipeId = 2, IngredientName = "Pollo", Amount = "500g" },
            new Ingredient { Id = 6, RecipeId = 2, IngredientName = "Curry en polvo", Amount = "2 cucharadas" },
            new Ingredient { Id = 7, RecipeId = 2, IngredientName = "Leche de coco", Amount = "400ml" },
            new Ingredient { Id = 8, RecipeId = 2, IngredientName = "Cebolla", Amount = "1" },
            new Ingredient { Id = 9, RecipeId = 3, IngredientName = "Lechuga", Amount = "200g" },
            new Ingredient { Id = 10, RecipeId = 3, IngredientName = "Crutones", Amount = "100g" },
            new Ingredient { Id = 11, RecipeId = 3, IngredientName = "Queso parmesano", Amount = "50g" },
            new Ingredient { Id = 12, RecipeId = 3, IngredientName = "Aderezo César", Amount = "50ml" },
            new Ingredient { Id = 13, RecipeId = 4, IngredientName = "Carne de cerdo", Amount = "500g" },
            new Ingredient { Id = 14, RecipeId = 4, IngredientName = "Piña", Amount = "100g" },
            new Ingredient { Id = 15, RecipeId = 4, IngredientName = "Tortillas de maíz", Amount = "8" },
            new Ingredient { Id = 16, RecipeId = 4, IngredientName = "Salsa", Amount = "50ml" },
            new Ingredient { Id = 17, RecipeId = 5, IngredientName = "Chocolate", Amount = "200g" },
            new Ingredient { Id = 18, RecipeId = 5, IngredientName = "Harina", Amount = "150g" },
            new Ingredient { Id = 19, RecipeId = 5, IngredientName = "Azúcar", Amount = "200g" },
            new Ingredient { Id = 20, RecipeId = 5, IngredientName = "Mantequilla", Amount = "100g" },
            new Ingredient { Id = 21, RecipeId = 6, IngredientName = "Masa para pizza", Amount = "1" },
            new Ingredient { Id = 22, RecipeId = 6, IngredientName = "Salsa de tomate", Amount = "100ml" },
            new Ingredient { Id = 23, RecipeId = 6, IngredientName = "Mozzarella", Amount = "150g" },
            new Ingredient { Id = 24, RecipeId = 6, IngredientName = "Albahaca", Amount = "10 hojas" },
            new Ingredient { Id = 25, RecipeId = 7, IngredientName = "Lentejas", Amount = "250g" },
            new Ingredient { Id = 26, RecipeId = 7, IngredientName = "Zanahoria", Amount = "1" },
            new Ingredient { Id = 27, RecipeId = 7, IngredientName = "Apio", Amount = "1 rama" },
            new Ingredient { Id = 28, RecipeId = 7, IngredientName = "Caldo de verduras", Amount = "1 litro" },
            new Ingredient { Id = 29, RecipeId = 8, IngredientName = "Manzanas", Amount = "4" },
            new Ingredient { Id = 30, RecipeId = 8, IngredientName = "Masa para tarta", Amount = "1" },
            new Ingredient { Id = 31, RecipeId = 8, IngredientName = "Azúcar", Amount = "100g" },
            new Ingredient { Id = 32, RecipeId = 8, IngredientName = "Canela", Amount = "1 cucharadita" },
            new Ingredient { Id = 33, RecipeId = 9, IngredientName = "Salmón", Amount = "200g" },
            new Ingredient { Id = 34, RecipeId = 9, IngredientName = "Arroz para sushi", Amount = "200g" },
            new Ingredient { Id = 35, RecipeId = 9, IngredientName = "Vinagre de arroz", Amount = "50ml" },
            new Ingredient { Id = 36, RecipeId = 9, IngredientName = "Algas nori", Amount = "5 hojas" },
            new Ingredient { Id = 37, RecipeId = 10, IngredientName = "Aguacate", Amount = "2" },
            new Ingredient { Id = 38, RecipeId = 10, IngredientName = "Tomate", Amount = "1" },
            new Ingredient { Id = 39, RecipeId = 10, IngredientName = "Cilantro", Amount = "1 manojo" },
            new Ingredient { Id = 40, RecipeId = 10, IngredientName = "Limón", Amount = "1" },
            new Ingredient { Id = 41, RecipeId = 11, IngredientName = "Harina", Amount = "200g" },
            new Ingredient { Id = 42, RecipeId = 11, IngredientName = "Leche", Amount = "250ml" },
            new Ingredient { Id = 43, RecipeId = 11, IngredientName = "Huevo", Amount = "1" },
            new Ingredient { Id = 44, RecipeId = 11, IngredientName = "Polvo de hornear", Amount = "1 cucharadita" },
            new Ingredient { Id = 45, RecipeId = 12, IngredientName = "Carne molida", Amount = "300g" },
            new Ingredient { Id = 46, RecipeId = 12, IngredientName = "Frijoles", Amount = "200g" },
            new Ingredient { Id = 47, RecipeId = 12, IngredientName = "Tomate", Amount = "1" },
            new Ingredient { Id = 48, RecipeId = 12, IngredientName = "Chile en polvo", Amount = "1 cucharada" },
            new Ingredient { Id = 49, RecipeId = 13, IngredientName = "Limón", Amount = "4" },
            new Ingredient { Id = 50, RecipeId = 13, IngredientName = "Azúcar", Amount = "200g" },
            new Ingredient { Id = 51, RecipeId = 13, IngredientName = "Masa para tarta", Amount = "1" },
            new Ingredient { Id = 52, RecipeId = 13, IngredientName = "Mantequilla", Amount = "100g" },
            new Ingredient { Id = 53, RecipeId = 14, IngredientName = "Calabacín", Amount = "1" },
            new Ingredient { Id = 54, RecipeId = 14, IngredientName = "Berenjena", Amount = "1" },
            new Ingredient { Id = 55, RecipeId = 14, IngredientName = "Pimiento", Amount = "1" },
            new Ingredient { Id = 56, RecipeId = 14, IngredientName = "Tomate", Amount = "2" },
            new Ingredient { Id = 57, RecipeId = 15, IngredientName = "Tortillas de maíz", Amount = "8" },
            new Ingredient { Id = 58, RecipeId = 15, IngredientName = "Carne de res", Amount = "300g" },
            new Ingredient { Id = 59, RecipeId = 15, IngredientName = "Salsa de chile", Amount = "100ml" },
            new Ingredient { Id = 60, RecipeId = 15, IngredientName = "Queso rallado", Amount = "50g" },
            new Ingredient { Id = 61, RecipeId = 16, IngredientName = "Arroz", Amount = "300g" },
            new Ingredient { Id = 62, RecipeId = 16, IngredientName = "Mariscos variados", Amount = "400g" },
            new Ingredient { Id = 63, RecipeId = 16, IngredientName = "Pimiento", Amount = "1" },
            new Ingredient { Id = 64, RecipeId = 16, IngredientName = "Caldo de pescado", Amount = "1 litro" },
            new Ingredient { Id = 65, RecipeId = 17, IngredientName = "Lácteo", Amount = "500ml" },
            new Ingredient { Id = 66, RecipeId = 17, IngredientName = "Harina", Amount = "200g" },
            new Ingredient { Id = 67, RecipeId = 17, IngredientName = "Huevos", Amount = "3" },
            new Ingredient { Id = 68, RecipeId = 17, IngredientName = "Azúcar", Amount = "150g" },
            new Ingredient { Id = 69, RecipeId = 18, IngredientName = "Pollo", Amount = "400g" },
            new Ingredient { Id = 70, RecipeId = 18, IngredientName = "Pimientos", Amount = "2" },
            new Ingredient { Id = 71, RecipeId = 18, IngredientName = "Cebolla", Amount = "1" },
            new Ingredient { Id = 72, RecipeId = 18, IngredientName = "Salsa de soya", Amount = "50ml" },
            new Ingredient { Id = 73, RecipeId = 19, IngredientName = "Pasta", Amount = "300g" },
            new Ingredient { Id = 74, RecipeId = 19, IngredientName = "Salsa de tomate", Amount = "200ml" },
            new Ingredient { Id = 75, RecipeId = 19, IngredientName = "Queso mozzarella", Amount = "100g" },
            new Ingredient { Id = 76, RecipeId = 19, IngredientName = "Albahaca fresca", Amount = "10 hojas" },
            new Ingredient { Id = 77, RecipeId = 20, IngredientName = "Calabaza", Amount = "1" },
            new Ingredient { Id = 78, RecipeId = 20, IngredientName = "Harina", Amount = "200g" },
            new Ingredient { Id = 79, RecipeId = 20, IngredientName = "Azúcar", Amount = "150g" },
            new Ingredient { Id = 80, RecipeId = 20, IngredientName = "Canela", Amount = "1 cucharadita" },
            new Ingredient { Id = 81, RecipeId = 21, IngredientName = "Masa para empanadas", Amount = "10 discos" },
            new Ingredient { Id = 82, RecipeId = 21, IngredientName = "Carne molida", Amount = "300g" },
            new Ingredient { Id = 83, RecipeId = 21, IngredientName = "Cebolla", Amount = "1" },
            new Ingredient { Id = 84, RecipeId = 21, IngredientName = "Pimiento", Amount = "1" },
            new Ingredient { Id = 85, RecipeId = 22, IngredientName = "Atún", Amount = "200g" },
            new Ingredient { Id = 86, RecipeId = 22, IngredientName = "Cebolla", Amount = "1" },
            new Ingredient { Id = 87, RecipeId = 22, IngredientName = "Tomate", Amount = "1" },
            new Ingredient { Id = 88, RecipeId = 22, IngredientName = "Mayonesa", Amount = "50ml" },
            new Ingredient { Id = 89, RecipeId = 23, IngredientName = "Arroz", Amount = "300g" },
            new Ingredient { Id = 90, RecipeId = 23, IngredientName = "Gambas", Amount = "200g" },
            new Ingredient { Id = 91, RecipeId = 23, IngredientName = "Pimientos", Amount = "2" },
            new Ingredient { Id = 92, RecipeId = 23, IngredientName = "Caldo de pescado", Amount = "500ml" },
            new Ingredient { Id = 93, RecipeId = 24, IngredientName = "Pan de hamburguesa", Amount = "4 panes" },
            new Ingredient { Id = 94, RecipeId = 24, IngredientName = "Carne de res", Amount = "400g" },
            new Ingredient { Id = 95, RecipeId = 24, IngredientName = "Queso cheddar", Amount = "4 rebanadas" },
            new Ingredient { Id = 96, RecipeId = 24, IngredientName = "Lechuga", Amount = "4 hojas" },
            new Ingredient { Id = 97, RecipeId = 25, IngredientName = "Calabaza", Amount = "1" },
            new Ingredient { Id = 98, RecipeId = 25, IngredientName = "Cebolla", Amount = "1" },
            new Ingredient { Id = 99, RecipeId = 25, IngredientName = "Pimiento", Amount = "1" },
            new Ingredient { Id = 100, RecipeId = 25, IngredientName = "Aceite de oliva", Amount = "50ml" },
            new Ingredient { Id = 101, RecipeId = 26, IngredientName = "Pan", Amount = "8 rebanadas" },
            new Ingredient { Id = 102, RecipeId = 26, IngredientName = "Aguacate", Amount = "2" },
            new Ingredient { Id = 103, RecipeId = 26, IngredientName = "Tomate", Amount = "1" },
            new Ingredient { Id = 104, RecipeId = 26, IngredientName = "Queso feta", Amount = "100g" },
            new Ingredient { Id = 105, RecipeId = 27, IngredientName = "Galletas", Amount = "200g" },
            new Ingredient { Id = 106, RecipeId = 27, IngredientName = "Mantequilla", Amount = "100g" },
            new Ingredient { Id = 107, RecipeId = 27, IngredientName = "Azúcar", Amount = "50g" },
            new Ingredient { Id = 108, RecipeId = 27, IngredientName = "Leche condensada", Amount = "200ml" },
            new Ingredient { Id = 109, RecipeId = 28, IngredientName = "Carne molida", Amount = "300g" },
            new Ingredient { Id = 110, RecipeId = 28, IngredientName = "Cebolla", Amount = "1" },
            new Ingredient { Id = 111, RecipeId = 28, IngredientName = "Pimiento", Amount = "1" },
            new Ingredient { Id = 112, RecipeId = 28, IngredientName = "Salsa de tomate", Amount = "100ml" },
            new Ingredient { Id = 113, RecipeId = 29, IngredientName = "Pechuga de pollo", Amount = "300g" },
            new Ingredient { Id = 114, RecipeId = 29, IngredientName = "Pimientos", Amount = "2" },
            new Ingredient { Id = 115, RecipeId = 29, IngredientName = "Cebolla", Amount = "1" },
            new Ingredient { Id = 116, RecipeId = 29, IngredientName = "Salsa de soya", Amount = "50ml" },
            new Ingredient { Id = 117, RecipeId = 30, IngredientName = "Queso crema", Amount = "200g" },
            new Ingredient { Id = 118, RecipeId = 30, IngredientName = "Galletas", Amount = "200g" },
            new Ingredient { Id = 119, RecipeId = 30, IngredientName = "Azúcar", Amount = "100g" },
            new Ingredient { Id = 120, RecipeId = 30, IngredientName = "Mantequilla", Amount = "100g" },
            new Ingredient { Id = 121, RecipeId = 31, IngredientName = "Espaguetis", Amount = "300g" },
            new Ingredient { Id = 122, RecipeId = 31, IngredientName = "Salsa de tomate", Amount = "200ml" },
            new Ingredient { Id = 123, RecipeId = 31, IngredientName = "Albahaca", Amount = "10 hojas" },
            new Ingredient { Id = 124, RecipeId = 31, IngredientName = "Queso parmesano", Amount = "50g" },
            new Ingredient { Id = 125, RecipeId = 32, IngredientName = "Pechuga de pollo", Amount = "400g" },
            new Ingredient { Id = 126, RecipeId = 32, IngredientName = "Pimientos", Amount = "2" },
            new Ingredient { Id = 127, RecipeId = 32, IngredientName = "Cebolla", Amount = "1" },
            new Ingredient { Id = 128, RecipeId = 32, IngredientName = "Salsa barbacoa", Amount = "50ml" },
            new Ingredient { Id = 129, RecipeId = 33, IngredientName = "Lechuga", Amount = "200g" },
            new Ingredient { Id = 130, RecipeId = 33, IngredientName = "Queso cheddar", Amount = "100g" },
            new Ingredient { Id = 131, RecipeId = 33, IngredientName = "Tomate", Amount = "1" },
            new Ingredient { Id = 132, RecipeId = 33, IngredientName = "Aderezo ranch", Amount = "50ml" },
            new Ingredient { Id = 133, RecipeId = 34, IngredientName = "Masa para empanadas", Amount = "10 discos" },
            new Ingredient { Id = 134, RecipeId = 34, IngredientName = "Carne de res", Amount = "300g" },
            new Ingredient { Id = 135, RecipeId = 34, IngredientName = "Cebolla", Amount = "1" },
            new Ingredient { Id = 136, RecipeId = 34, IngredientName = "Pimiento", Amount = "1" },
            new Ingredient { Id = 137, RecipeId = 35, IngredientName = "Harina", Amount = "200g" },
            new Ingredient { Id = 138, RecipeId = 35, IngredientName = "Azúcar", Amount = "150g" },
            new Ingredient { Id = 139, RecipeId = 35, IngredientName = "Mantequilla", Amount = "100g" },
            new Ingredient { Id = 140, RecipeId = 35, IngredientName = "Chocolate", Amount = "100g" },
            new Ingredient { Id = 141, RecipeId = 36, IngredientName = "Masa para pizza", Amount = "1" },
            new Ingredient { Id = 142, RecipeId = 36, IngredientName = "Salsa de tomate", Amount = "100ml" },
            new Ingredient { Id = 143, RecipeId = 36, IngredientName = "Mozzarella", Amount = "150g" },
            new Ingredient { Id = 144, RecipeId = 36, IngredientName = "Jamón", Amount = "100g" },
            new Ingredient { Id = 145, RecipeId = 37, IngredientName = "Pechuga de pollo", Amount = "300g" },
            new Ingredient { Id = 146, RecipeId = 37, IngredientName = "Queso crema", Amount = "150g" },
            new Ingredient { Id = 147, RecipeId = 37, IngredientName = "Espárragos", Amount = "100g" },
            new Ingredient { Id = 148, RecipeId = 37, IngredientName = "Ajo", Amount = "2 dientes" },
            new Ingredient { Id = 149, RecipeId = 38, IngredientName = "Harina", Amount = "200g" },
            new Ingredient { Id = 150, RecipeId = 38, IngredientName = "Azúcar", Amount = "150g" },
            new Ingredient { Id = 151, RecipeId = 38, IngredientName = "Mantequilla", Amount = "100g" },
            new Ingredient { Id = 152, RecipeId = 38, IngredientName = "Manzana", Amount = "2" },
            new Ingredient { Id = 153, RecipeId = 39, IngredientName = "Tortillas de maíz", Amount = "8" },
            new Ingredient { Id = 154, RecipeId = 39, IngredientName = "Carne de cerdo", Amount = "400g" },
            new Ingredient { Id = 155, RecipeId = 39, IngredientName = "Salsa de chile", Amount = "100ml" },
            new Ingredient { Id = 156, RecipeId = 39, IngredientName = "Cebolla", Amount = "1" },
            new Ingredient { Id = 157, RecipeId = 40, IngredientName = "Pan de hamburguesa", Amount = "4 panes" },
            new Ingredient { Id = 158, RecipeId = 40, IngredientName = "Carne de res", Amount = "400g" },
            new Ingredient { Id = 159, RecipeId = 40, IngredientName = "Queso cheddar", Amount = "4 rebanadas" },
            new Ingredient { Id = 160, RecipeId = 40, IngredientName = "Lechuga", Amount = "4 hojas" },
        };

        #endregion
        public List<IngredientsDTO> GetIngredients (int recipeId)
        {
            List<IngredientsDTO> list = new List<IngredientsDTO>();

            foreach(var item in ingredientsList)
            {
                if (item.RecipeId == recipeId)
                {
                    IngredientsDTO ing = new IngredientsDTO
                    {
                        IngredientName = item.IngredientName,
                        Amount = item.Amount,
                    };

                    list.Add(ing);
                }
            }

            return list;
        }
    }
}
