using EasyCook3.Core.Interfaces;
using EasyCook3.Models;
using EasyCook3.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core
{
    public  class CommentService : ICommentService
    {
        private readonly IUserService _userService;
        #region LISTA DE COMENTARIOS

        List<Comment> comments = new List<Comment>
        {
            new Comment { Id = 1, RecipeId = 7, UserId = 3, Date = "15-03-2022", Description = "¡Receta deliciosa, la volveré a intentar!" },
            new Comment { Id = 2, RecipeId = 12, UserId = 2, Date = "22-11-2021", Description = "No está mal, pero podría usar un poco más de condimento." },
            new Comment { Id = 3, RecipeId = 35, UserId = 1, Date = "08-07-2020", Description = "¡Me encantó! A toda mi familia le gustó." },
            new Comment { Id = 4, RecipeId = 21, UserId = 4, Date = "14-01-2019", Description = "Estuvo bien, pero creo que necesita más sabor." },
            new Comment { Id = 5, RecipeId = 36, UserId = 5, Date = "19-06-2018", Description = "¡Receta fantástica! La recomiendo mucho." },
            new Comment { Id = 6, RecipeId = 8, UserId = 6, Date = "27-08-2023", Description = "El sabor fue genial, pero el tiempo de cocción estaba desajustado." },
            new Comment { Id = 7, RecipeId = 3, UserId = 2, Date = "30-04-2017", Description = "Fácil de seguir y quedó genial." },
            new Comment { Id = 8, RecipeId = 16, UserId = 3, Date = "02-12-2016", Description = "Tuve algunos problemas con la receta, pero estaba sabrosa." },
            new Comment { Id = 9, RecipeId = 35, UserId = 1, Date = "11-10-2015", Description = "Esta receta es un tesoro, ¡gracias!" },
            new Comment { Id = 10, RecipeId = 19, UserId = 4, Date = "05-09-2022", Description = "No salió como esperaba, pero aún así estuvo buena." },
            new Comment { Id = 11, RecipeId = 10, UserId = 5, Date = "16-03-2024", Description = "Receta perfecta para una comida rápida." },
            new Comment { Id = 12, RecipeId = 27, UserId = 6, Date = "22-06-2021", Description = "Añadiría un poco más de sal la próxima vez." },
            new Comment { Id = 13, RecipeId = 4, UserId = 3, Date = "10-11-2022", Description = "Las instrucciones estaban claras y fáciles de seguir." },
            new Comment { Id = 14, RecipeId = 9, UserId = 1, Date = "03-01-2023", Description = "Gran plato, definitivamente lo haré de nuevo." },
            new Comment { Id = 15, RecipeId = 30, UserId = 2, Date = "14-07-2022", Description = "No estoy seguro si seguí bien la receta, pero estuvo buena." },
            new Comment { Id = 16, RecipeId = 20, UserId = 4, Date = "09-08-2021", Description = "La lista de ingredientes era un poco confusa." },
            new Comment { Id = 17, RecipeId = 35, UserId = 5, Date = "25-12-2022", Description = "Me encantó la textura, pero el sabor le faltaba algo." },
            new Comment { Id = 18, RecipeId = 12, UserId = 6, Date = "17-02-2023", Description = "¡Excelente receta, muy sabrosa!" },
            new Comment { Id = 19, RecipeId = 35, UserId = 3, Date = "01-05-2021", Description = "Sugeriría probarla con menos azúcar." },
            new Comment { Id = 20, RecipeId = 40, UserId = 2, Date = "28-11-2023", Description = "Un poco picante para mi gusto, pero aún así disfruté." }
        };

        #endregion

        public CommentService(IUserService userService)
        {
            _userService = userService;
        }
        public List<CommentDTO> GetComments(int recipeId)
        {
            List<CommentDTO> list = new List<CommentDTO>();

            foreach(var item in comments)
            {
                if (item.RecipeId == recipeId)
                {
                    CommentDTO com = new CommentDTO
                    {
                        Username = _userService.GetUser(item.UserId).Username,
                        Date = item.Date,
                        Description = item.Description,
                    };

                    list.Add(com);
                }
            }

            return list;
        }
    }
}
