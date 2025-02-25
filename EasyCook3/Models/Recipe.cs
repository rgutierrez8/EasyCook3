using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace EasyCook3.Models
{
    [Table("Recipe")]
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripe { get; set; }
        public string MainImage { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public string NeededTime { get; set; }
        public string Username { get; set; }
        public int Like { get; set; }
        public int DontLike { get;set; }
    }
}
