using EasyCook3.Core.Interfaces;
using EasyCook3.Models.DTO;
using EasyCook3.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.ViewModels
{
    public class RecipeVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRecipeService _recipeService;
        private readonly IFavService _favService;
        private readonly IUserService _userService;
        
        private int _recipeId { get; set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private RecipeDTO _recipe;

        public RecipeDTO RecipeDetail
        {
            get { return _recipe; }

            set
            {
                _recipe = value;
                OnPropertyChanged(nameof(RecipeDetail));
            }
        }

        public int RecipeId
        {
            get => _recipeId;
            set
            {
                if (_recipeId != value)
                {
                    _recipeId = value;
                    OnPropertyChanged(nameof(RecipeId));
                }
            }
        }

        public RecipeVM(int recipeId, IRecipeService recipeService, IFavService favService, IUserService userService)
        {
            _recipeService = recipeService;
            _recipeId = recipeId;
            _favService = favService;
            _userService = userService;

            RecipeDetail = _recipeService.GetRecipe(recipeId);
        }
    }
}
