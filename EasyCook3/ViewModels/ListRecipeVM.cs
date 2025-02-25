using EasyCook3.Core.Helpers;
using EasyCook3.Core.Interfaces;
using EasyCook3.Data;
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
        private readonly Mapper _mapper;
        private readonly MySQLiService _mydb;

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

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
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
            IsLoading = true;
            var serviceProvider = MauiProgram.CreateMauiApp().Services;
            _mapper = serviceProvider.GetService<Mapper>();
            _recipeService = recipeService;
            _mydb = serviceProvider.GetService<MySQLiService>();

            if (CheckConnectivity())
            {
                try
                {
                    Init();
                }
                finally
                {
                    IsLoading = false;
                }
            }
            else
            {
                try
                {
                    InitOffline();
                }
                finally
                {
                    IsLoading = false;
                }
            }

        }

        public async void Init()
        {
            ListRecipes = await _recipeService.GetAll(_order);
            UpdateListRecipes(_order);
        }
        public async Task InitOffline()
        {
            var lisDTO = new List<RecipesListDTO>();
            var data = await _mydb.GetRecipesAsync();

            ListRecipes = _mapper.MapRecipeToRecipesListDTO(data);
        }

        public async void UpdateListRecipes(int order)
        {
            IsLoading = true;
            try
            {
                ListRecipes = await _recipeService.GetAll(order);
            }
            finally
            {
                IsLoading = false;
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
