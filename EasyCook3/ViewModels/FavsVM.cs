using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCook3.Core.Helpers;
using EasyCook3.Core.Interfaces;
using EasyCook3.Data;
using EasyCook3.Models;
using EasyCook3.Models.DTO;
using SQLite;

namespace EasyCook3.ViewModels
{
    public class FavsVM : INotifyPropertyChanged
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;
        private readonly MySQLiService _mydb;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<RecipesListDTO> _recipes;

        public List<RecipesListDTO> ListRecipes
        {

            get { return _recipes; }
            set
            {
                _recipes = value;
                OnPropertyChanged(nameof(ListRecipes));
            }
        }

        public FavsVM(IRecipeService recipeService)
        {
            var serviceProvider = MauiProgram.CreateMauiApp().Services;
            _mapper = serviceProvider.GetService<IMapper>();
            _recipeService = recipeService;
            _mydb = serviceProvider.GetService<MySQLiService>();

            InsertRecipeMySQLi();

            if(CheckConnectivity())
            {
                AwaitRecipes();
            }
            else
            {
                AwaitRecipesOffline();
            }
        }

        public async void AwaitRecipes()
        {
            ListRecipes = await _recipeService.GetFavsUser();
        }
        public async void AwaitRecipesOffline()
        {
            var data = await _mydb.GetRecipesAsync();

            ListRecipes = _mapper.MapRecipeToRecipesListDTO(data);
        }
        public async Task RefreshRecipes()
        {
            ListRecipes = await _recipeService.GetFavsUser();
        }
        public async Task InsertRecipeMySQLi()
        {
            var items = await _recipeService.GetAllInFav();

            if (items != null)
            {
                foreach (var item in items)
                {
                    Recipe recipeCopy = new Recipe()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Descripe = item.Describe,
                        MainImage = item.MainImage,
                        Img2 = item.Img2,
                        Img3 = item.Img3,
                        Img4 = item.Img4,
                        NeededTime = item.NeededTime,
                        Username = item.Username,
                        Like = item.Like,
                        DontLike = item.dontLike
                    };
                    await _mydb.AddRecipeAsync(recipeCopy);

                    foreach (var item2 in item.ListIngredients)
                    {
                        Ingredient ingredient = new Ingredient()
                        {
                            Id = item.Id,
                            Amount = item2.Amount,
                            IngredientName = item2.IngredientName
                        };

                        await _mydb.AddIngredientAsync(ingredient);
                    }

                    foreach (var item3 in item.ListSteps)
                    {
                        Step step = new Step()
                        {
                            Id = item.Id,
                            NumberStep = item3.NumberStep,
                            Description = item3.Describe
                        };

                        await _mydb.AddStepAsync(step);
                    }

                    foreach (var item4 in item.CommentList)
                    {
                        Comment comment = new Comment()
                        {
                            RecipeId = item.Id,
                            Username = item4.Username,
                            Description = item4.Describe
                        };

                        await _mydb.AddCommentAsync(comment);
                    }
                }
            }
        }
        public bool CheckConnectivity()
        {
            var Current = Connectivity.Current;

            if (Current.NetworkAccess == NetworkAccess.Internet)
            {
                return true;
            }

            return false;
        }
    }
}
