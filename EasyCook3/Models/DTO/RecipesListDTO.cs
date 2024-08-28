using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Models.DTO
{
    public class RecipesListDTO
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string MainImage { get; set; }
		public string Time {  get; set; }
		public string Username {  get; set; }
		public int Like {  get; set; }
		public int dontLike { get; set; }
		public string TimeToCompare { get; set; }
    }
}
