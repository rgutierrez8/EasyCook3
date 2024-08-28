using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int UserId {  get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
