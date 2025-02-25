using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace EasyCook3.Models
{
    [Table("Ingredient")]
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string IngredientName {  get; set; }
        public string Amount { get; set; }
    }
}
