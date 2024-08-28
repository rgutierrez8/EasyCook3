using EasyCook3.Models.DTO;
using EasyCook3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EasyCook3.Core.Interfaces;
using EasyCook3.Core;

namespace EasyCook3.ViewModels
{
    public class UserVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private UserDTO _user;

        public UserDTO Userdto
        {
            get { return _user; }

            set
            {
                _user = value;
                OnPropertyChanged(nameof(Userdto));
            }
        }

        public UserVM(IUserService userService, IRecipeService recipeService)
        {
            _userService = userService;
            _recipeService = recipeService;


            User user = userService.GetUser(6);

            if (user != null)
            {
                Userdto = new UserDTO()
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.Username,
                    Pic = user.Pic,
                    Banner = user.Banner,
                    CountRecipes = _recipeService.GetRecipesByUser(user.Id).Count,
                    Recipes = _recipeService.GetRecipesByUser(user.Id),
                };
            }
        }
    }
}
