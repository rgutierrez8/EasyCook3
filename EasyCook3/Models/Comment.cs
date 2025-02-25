using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Models
{
    [Table("Comment")]
    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Username {  get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
