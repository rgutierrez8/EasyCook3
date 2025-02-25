using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace EasyCook3.Models
{
    [Table("Step")]
    public class Step
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int NumberStep { get; set; }
        public string Description { get; set; }
    }
}
