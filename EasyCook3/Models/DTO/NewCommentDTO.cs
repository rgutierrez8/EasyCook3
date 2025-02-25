using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Models.DTO
{
    public class NewCommentDTO
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public string Describe { get; set; }
    }
}
