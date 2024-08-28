using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EasyCook3.Models.DTO;

namespace EasyCook3.Models.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IngredientsDTO> ListIngredients { get; set; }
        public List<StepDTO> ListSteps { get; set; }
        public string MainImage { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public string Time { get; set; }
        public string Username { get; set; }
        public int Like { get; set; }
        public int dontLike { get; set; }
        public List<CommentDTO> CommentList { get; set; }
        public bool InFav { get; set; }
    }
}
