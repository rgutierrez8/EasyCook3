using EasyCook3.Core.Helpers;
using EasyCook3.Core.Interfaces;
using EasyCook3.Data;
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
        private readonly IMapper _mapper;
        private readonly MySQLiService _mydb;
        private int _recipeId { get; set; }
        

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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


        public RecipeVM(IRecipeService recipeService, IFavService favService, IUserService userService)
        {
            var serviceProvider = MauiProgram.CreateMauiApp().Services;
            _mapper = serviceProvider.GetService<IMapper>();
            _recipeService = recipeService;
            _favService = favService;
            _userService = userService;
            _mydb = serviceProvider.GetService<MySQLiService>();
        }

        public async Task LoadRecipe(int recipeId)
        {
            IsLoading = true;

            if (CheckConnectivity())
            {
                try
                {
                    var data = await _recipeService.GetRecipe(recipeId);
                    RecipeDetail = data;
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
                    var data = await GetRecipeFromMySQLi(recipeId);
                    RecipeDetail = data;
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        public async Task<RecipeDTO> GetRecipeFromMySQLi(int recipeId)
        {
            var users = await _mydb.GetAllUser();
            var recipes = await _mydb.GetRecipesAsync();
            var ingredients = await _mydb.getallingredient();
            var steps = await _mydb.getallstep();
            var coments = await _mydb.getallcomment();

            var recipe = await _mapper.MapRecipeToRecipeDTO(await _mydb.ReturnRecipe(recipeId));

            return recipe;
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
