using EasyCook3.Models;
using EasyCook3.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core.Interfaces
{
    public interface IFavService
    {
        public List<Fav> GetFavs(int userId);
        public Boolean InFavs(int recipeId, int userId);
    }
}
