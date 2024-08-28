using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCook3.Models.DTO;

namespace EasyCook3.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Pic { get; set; }
        public string Banner { get; set; }
        public int CountRecipes { get; set; }
        public List<RecipesListDTO> Recipes {  get; set; }
    }
}
