using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCook3.Core.Interfaces;
using EasyCook3.Models.DTO;

namespace EasyCook3.ViewModels
{
    public class FavsVM : INotifyPropertyChanged
    {
        private readonly IFavService _favService;
        private readonly IRecipeService _recipeService;
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

        public FavsVM(IFavService favService, IRecipeService recipeService)
        {
            _favService = favService;
            _recipeService = recipeService;

            ListRecipes = _recipeService.GetFavsUser(_favService.GetFavs(6)); //USER ID HARDCODEADA HASTA TENER ID DE USUARIO LOGEADO
        }
    }
}
