using EasyCook3.Core.Interfaces;
using EasyCook3.Models;
using EasyCook3.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.ViewModels
{
    public class ListRecipeVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRecipeService _recipeService;

        private int _order;
        public int Order
        {
            get => _order;
            set
            {
                if (_order != value)
                {
                    _order = value;
                    OnPropertyChanged(nameof(Order));
                    UpdateListRecipes(_order);
                }
            }
        }

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

        public ListRecipeVM(IRecipeService recipeService)
        {
            _recipeService = recipeService;

            ListRecipes = _recipeService.GetAll(_order);
            UpdateListRecipes(_order);
        }

        public void UpdateListRecipes(int order)
        {
            ListRecipes = _recipeService.GetAll(order);
        }
    }
}
