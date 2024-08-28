using EasyCook3.Core.Interfaces;
using EasyCook3.Core.Helpers;
using EasyCook3.Models.DTO;
using EasyCook3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace EasyCook3.Core
{
    public class RecipeService : IRecipeService
    {
        private readonly IUserService _userService;
        private readonly IIngredientService _ingredientService;
        private readonly IStepService _stepService;
        private readonly ICommentService _commentService;
        private readonly IHelper _helperService;
        public RecipeService(IUserService userService, IIngredientService ingredientService, IStepService stepService, ICommentService commentService, IHelper helperService)
        {
            _userService = userService;
            _ingredientService = ingredientService;
            _stepService = stepService;
            _commentService = commentService;
            _helperService = helperService;
        }

        #region LISTA DE RECETAS

        List<Recipe> list = new List<Recipe>()
        {
            new Recipe{
                Id= 1,
                Title=  "Pasta Carbonara",
                Description=  "Un clásico plato italiano de pasta hecho con huevos, queso, panceta y pimienta.",
                MainImage=  "https://source.unsplash.com/2rG8mT-Kj2s",
                Img2=  "https://source.unsplash.com/WsbdPpRp5sM",
                Img3=  "https://source.unsplash.com/OMK-QF2ynr4",
                Img4=  "https://source.unsplash.com/De6cJOrNZWg",
                Time=  "30", // minutos
                UserId= 1,
                Like=  245,
                DontLike=  12
            },
            new Recipe{
                Id= 2,
                Title=  "Pollo al Curry",
                Description=  "Un sabroso curry hecho con pollo tierno y una mezcla de especias.",
                MainImage=  "https://source.unsplash.com/QwQx-ZeoQ8o",
                Img2=  "https://source.unsplash.com/6d5x6Kk--3k",
                Img3=  "https://source.unsplash.com/fDPcB5Xnvw8",
                Img4=  "https://source.unsplash.com/87bnjIVmETk",
                Time=  "40", // minutos
                UserId= 2,
                Like=  320,
                DontLike=  8
            },
            new Recipe{
                Id= 3,
                Title=  "Ensalada César",
                Description=  "Una ensalada fresca con lechuga, crutones, queso parmesano y aderezo César.",
                MainImage=  "https://source.unsplash.com/6fywWJY0wGQ",
                Img2=  "https://source.unsplash.com/Z-4rHgl3Tdo",
                Img3=  "https://source.unsplash.com/n0fdvS7DDhM",
                Img4=  "https://source.unsplash.com/oGFAZGm_C7g",
                Time=  "20", // minutos
                UserId= 3,
                Like=  150,
                DontLike=  5
            },
            new Recipe{
                Id= 4,
                Title=  "Tacos al Pastor",
                Description=  "Tacos mexicanos con cerdo marinado, piña y salsa, servidos en tortillas de maíz.",
                MainImage=  "https://source.unsplash.com/KYogmA-9CLM",
                Img2=  "https://source.unsplash.com/ZT0dUBh9_Q8",
                Img3=  "https://source.unsplash.com/EhC4VVkK7H8",
                Img4=  "https://source.unsplash.com/CcQsf9aUpRg",
                Time=  "30", // minutos
                UserId= 4,
                Like=  400,
                DontLike=  15
            },
            new Recipe{
                Id= 5,
                Title=  "Brownies de Chocolate",
                Description=  "Deliciosos brownies de chocolate con una textura densa y húmeda.",
                MainImage=  "https://source.unsplash.com/Lp1k1A1LUwE",
                Img2=  "https://source.unsplash.com/Czy4Mb_tczM",
                Img3=  "https://source.unsplash.com/OdFJ3qNkRHI",
                Img4=  "https://source.unsplash.com/1HaPuj5L5CI",
                Time=  "45", // minutos
                UserId= 5,
                Like=  560,
                DontLike=  20
            },
            new Recipe{
                Id= 6,
                Title=  "Pizza Margherita",
                Description=  "Pizza clásica con salsa de tomate, mozzarella y albahaca.",
                MainImage=  "https://source.unsplash.com/0EJzk-aAFIk",
                Img2=  "https://source.unsplash.com/ZF8WcUeZfM8",
                Img3=  "https://source.unsplash.com/FH6zZxruSP0",
                Img4=  "https://source.unsplash.com/Wy9RjnJL6J0",
                Time=  "25", // minutos
                UserId= 6,
                Like=  315,
                DontLike=  7
            },
            new Recipe{
                Id= 7,
                Title=  "Sopa de Lentejas",
                Description=  "Una sopa nutritiva y reconfortante hecha con lentejas y verduras.",
                MainImage=  "https://source.unsplash.com/4Pe55hA0hXk",
                Img2=  "https://source.unsplash.com/oW-5sP4Ug4k",
                Img3=  "https://source.unsplash.com/Oe2SAV38C6g",
                Img4=  "https://source.unsplash.com/NJrk8ylNO84",
                Time=  "50", // minutos
                UserId= 1,
                Like=  210,
                DontLike=  6
            },
            new Recipe{
                Id= 8,
                Title=  "Tarta de Manzana",
                Description=  "Un postre delicioso con manzanas y una base de masa crujiente.",
                MainImage=  "https://source.unsplash.com/BF2J27FOqXA",
                Img2=  "https://source.unsplash.com/39D3irDYPm4",
                Img3=  "https://source.unsplash.com/4lv3dA6TBCs",
                Img4=  "https://source.unsplash.com/dLzFllah1Hc",
                Time=  "60", // minutos
                UserId= 1,
                Like=  485,
                DontLike=  11
            },
            new Recipe{
                Id= 9,
                Title=  "Sushi de Salmón",
                Description=  "Sushi fresco con salmón crudo y arroz sazonado.",
                MainImage=  "https://source.unsplash.com/YiEOTY4V4cU",
                Img2=  "https://source.unsplash.com/XmLR4O_5PTU",
                Img3=  "https://source.unsplash.com/FMC2W7w06JQ",
                Img4=  "https://source.unsplash.com/5dJcI1n3x5k",
                Time=  "40", // minutos
                UserId= 6,
                Like=  270,
                DontLike=  10
            },
            new Recipe{
                Id= 10,
                Title=  "Guacamole",
                Description=  "Una salsa mexicana a base de aguacate, tomate y cilantro.",
                MainImage=  "https://source.unsplash.com/4Bvt4X6dmMQ",
                Img2=  "https://source.unsplash.com/3Wm8QeMjS0U",
                Img3=  "https://source.unsplash.com/Ge_qXkjZ2h0",
                Img4=  "https://source.unsplash.com/FG1L4qM0k4I",
                Time=  "15", // minutos
                UserId= 6,
                Like=  395,
                DontLike=  8
            },
            new Recipe{
                Id= 11,
                Title=  "Pancakes",
                Description=  "Deliciosos pancakes esponjosos, perfectos para un desayuno completo.",
                MainImage=  "https://source.unsplash.com/6d0A3QlxkUI",
                Img2=  "https://source.unsplash.com/ae3V0Y5C2Xs",
                Img3=  "https://source.unsplash.com/xzUoDg28uJ0",
                Img4=  "https://source.unsplash.com/Dxj0tI_vwX8",
                Time=  "20", // minutos
                UserId= 6,
                Like=  320,
                DontLike=  7
            },
            new Recipe{
                Id= 12,
                Title=  "Chili con Carne",
                Description=  "Un guiso picante de carne y frijoles, ideal para una comida abundante.",
                MainImage=  "https://source.unsplash.com/IbZpUuQ0Lgo",
                Img2=  "https://source.unsplash.com/ZpmbzZKJlRg",
                Img3=  "https://source.unsplash.com/3z6q6xiCyKE",
                Img4=  "https://source.unsplash.com/YyHkb2Q9OV0",
                Time=  "50", // minutos
                UserId= 6,
                Like=  425,
                DontLike=  12
            },
            new Recipe{
                Id= 13,
                Title=  "Tarta de Limón",
                Description=  "Una tarta refrescante con un relleno de limón y una base crujiente.",
                MainImage=  "https://source.unsplash.com/ftFS4FPFQfg",
                Img2=  "https://source.unsplash.com/j48S9-tTRCw",
                Img3=  "https://source.unsplash.com/GosFHRk0e_8",
                Img4=  "https://source.unsplash.com/8R4NWXyDR1I",
                Time=  "60", // minutos
                UserId= 2,
                Like=  340,
                DontLike=  14
            },
            new Recipe{
                Id= 14,
                Title=  "Ratatouille",
                Description=  "Un guiso de verduras a la provenzal, ideal para acompañar cualquier plato.",
                MainImage=  "https://source.unsplash.com/cOZ8a_CGRd0",
                Img2=  "https://source.unsplash.com/zAXwW7Tn5Og",
                Img3=  "https://source.unsplash.com/XmkP7zS7ShM",
                Img4=  "https://source.unsplash.com/Cc2zJlo94G4",
                Time=  "45", // minutos
                UserId= 2,
                Like=  310,
                DontLike=  9
            },
            new Recipe{
                Id= 15,
                Title=  "Enchiladas",
                Description=  "Tortillas rellenas de carne y cubiertas con salsa de chile.",
                MainImage=  "https://source.unsplash.com/1nIt-QJ4R_o",
                Img2=  "https://source.unsplash.com/2xI9K7oTaZs",
                Img3=  "https://source.unsplash.com/q7AXBz-ULl4",
                Img4=  "https://source.unsplash.com/4P1ZQKT3_Os",
                Time=  "35", // minutos
                UserId= 2,
                Like=  365,
                DontLike=  13
            },
            new Recipe{
                Id= 16,
                Title=  "Paella",
                Description=  "Un plato tradicional español con arroz, mariscos y verduras.",
                MainImage=  "https://source.unsplash.com/0eAF6eRzW6k",
                Img2=  "https://source.unsplash.com/xXmrPIsC_Y0",
                Img3=  "https://source.unsplash.com/kPxA6HT4xNc",
                Img4=  "https://source.unsplash.com/03HKe4lT4yI",
                Time=  "70", // minutos
                UserId= 3,
                Like=  500,
                DontLike=  22
            },
            new Recipe{
                Id= 17,
                Title=  "Ceviche",
                Description=  "Pescado marinado en jugo de limón con cebolla, cilantro y chile.",
                MainImage=  "https://source.unsplash.com/xPqYgZQ4g38",
                Img2=  "https://source.unsplash.com/j_rk2OYthDo",
                Img3=  "https://source.unsplash.com/BHnRB8PSd2o",
                Img4=  "https://source.unsplash.com/5_0C2DEkMOI",
                Time=  "30", // minutos
                UserId= 3,
                Like=  420,
                DontLike=  9
            },
            new Recipe{
                Id= 18,
                Title=  "Goulash",
                Description=  "Un estofado húngaro de carne y paprika, ideal para días fríos.",
                MainImage=  "https://source.unsplash.com/7k5S_0PGz6Y",
                Img2=  "https://source.unsplash.com/1ICiy5h12WA",
                Img3=  "https://source.unsplash.com/2SIfxYXM7Q0",
                Img4=  "https://source.unsplash.com/2ysElbTzj2E",
                Time=  "60", // minutos
                UserId= 3,
                Like=  330,
                DontLike=  16
            },
            new Recipe{
                Id= 19,
                Title=  "Fettuccine Alfredo",
                Description=  "Pasta fettuccine con una cremosa salsa Alfredo de queso y crema.",
                MainImage=  "https://source.unsplash.com/h_9ysR9i0jw",
                Img2=  "https://source.unsplash.com/BixsdaQav6o",
                Img3=  "https://source.unsplash.com/JzvGbLCBz6Q",
                Img4=  "https://source.unsplash.com/uzkxzsy7JU8",
                Time=  "30", // minutos
                UserId= 4,
                Like=  280,
                DontLike=  11
            },
            new Recipe{
                Id= 20,
                Title=  "Falafel",
                Description=  "Croquetas fritas a base de garbanzos, ideales para acompañar ensaladas.",
                MainImage=  "https://source.unsplash.com/FgB5XzoWsDA",
                Img2=  "https://source.unsplash.com/lJ8uPqMA9LQ",
                Img3=  "https://source.unsplash.com/ZwzrKksk6vE",
                Img4=  "https://source.unsplash.com/S2YoA3i8Kv8",
                Time=  "40", // minutos
                UserId= 5,
                Like=  310,
                DontLike=  10
            },
            new Recipe{
                Id= 21,
                Title=  "Crepes",
                Description=  "Delgadas y suaves crepes que puedes rellenar con frutas, crema o chocolate.",
                MainImage=  "https://source.unsplash.com/FHsAlQH3NYs",
                Img2=  "https://source.unsplash.com/RGeh_U3xM7E",
                Img3=  "https://source.unsplash.com/7xzF4Kn9N7M",
                Img4=  "https://source.unsplash.com/6TynLbUktpA",
                Time=  "25", // minutos
                UserId= 6,
                Like=  340,
                DontLike=  7
            },
            new Recipe{
                Id= 22,
                Title=  "Ramen",
                Description=  "Sopa de fideos japonesa con caldo rico, carne, huevo y verduras.",
                MainImage=  "https://source.unsplash.com/_j5gbMAa6e8",
                Img2=  "https://source.unsplash.com/l_SJb8Dw7Oo",
                Img3=  "https://source.unsplash.com/5oZX0t9JQfE",
                Img4=  "https://source.unsplash.com/5e10rCVBR_k",
                Time=  "45", // minutos
                UserId= 6,
                Like=  390,
                DontLike=  14
            },
            new Recipe{
                Id= 23,
                Title=  "Tiramisu",
                Description=  "Postre italiano de capas de bizcocho empapadas en café con crema mascarpone.",
                MainImage=  "https://source.unsplash.com/OMsYTyCneF4",
                Img2=  "https://source.unsplash.com/JDhd3GA7Jkw",
                Img3=  "https://source.unsplash.com/OleJhLSiDRc",
                Img4=  "https://source.unsplash.com/OWzQ5_5MO4I",
                Time=  "50", // minutos
                UserId= 2,
                Like=  470,
                DontLike=  15
            },
            new Recipe{
                Id= 24,
                Title=  "Pollo a la Barbacoa",
                Description=  "Pollo marinado y cocido a la barbacoa, con un sabor ahumado y dulce.",
                MainImage=  "https://source.unsplash.com/XF3ApIv8NAI",
                Img2=  "https://source.unsplash.com/XvOcnKNlKSw",
                Img3=  "https://source.unsplash.com/FVnIowKYcRA",
                Img4=  "https://source.unsplash.com/E_h2rHkw7Tk",
                Time=  "60", // minutos
                UserId= 4,
                Like=  540,
                DontLike=  18
            },
            new Recipe{
                Id= 25,
                Title=  "Quiche Lorraine",
                Description=  "Una tarta salada con tocino y queso en una base de masa quebrada.",
                MainImage=  "https://source.unsplash.com/9lkoJm7fQNk",
                Img2=  "https://source.unsplash.com/x82i-VLVccM",
                Img3=  "https://source.unsplash.com/GjM7V-HdE10",
                Img4=  "https://source.unsplash.com/HD5nmHkXLo4",
                Time=  "50", // minutos
                UserId= 5,
                Like=  290,
                DontLike=  12
            },
            new Recipe{
                Id= 26,
                Title=  "Papas Bravas",
                Description=  "Papas fritas acompañadas de una salsa picante y alioli.",
                MainImage=  "https://source.unsplash.com/NjKGG01nZPA",
                Img2=  "https://source.unsplash.com/5AkT7kGc6c0",
                Img3=  "https://source.unsplash.com/R6Lh1An9Xrg",
                Img4=  "https://source.unsplash.com/SW1HRBe4FWc",
                Time=  "35", // minutos
                UserId= 6,
                Like=  375,
                DontLike=  10
            },
            new Recipe{
                Id= 27,
                Title=  "Huevos Benedictinos",
                Description=  "Huevos poché sobre pan tostado con salsa holandesa.",
                MainImage=  "https://source.unsplash.com/UK-Rc8v-tIU",
                Img2=  "https://source.unsplash.com/QleXWJsLPQI",
                Img3=  "https://source.unsplash.com/QWbVu3CCUdo",
                Img4=  "https://source.unsplash.com/SB4fRQe82j4",
                Time=  "30", // minutos
                UserId= 2,
                Like=  300,
                DontLike=  8
            },
            new Recipe{
                Id= 28,
                Title=  "Moussaka",
                Description=  "Plato griego con capas de berenjena, carne y bechamel.",
                MainImage=  "https://source.unsplash.com/_HQ4UbAZdcU",
                Img2=  "https://source.unsplash.com/K4yw8gybWg4",
                Img3=  "https://source.unsplash.com/v3c0K_5seTo",
                Img4=  "https://source.unsplash.com/x9bu7DwbJ7E",
                Time=  "70", // minutos
                UserId= 1,
                Like=  250,
                DontLike=  14
            },
            new Recipe{
                Id= 29,
                Title=  "Canelones de Carne",
                Description=  "Pasta rellena de carne en una salsa de tomate y bechamel.",
                MainImage=  "https://source.unsplash.com/xV0ar8a1dtE",
                Img2=  "https://source.unsplash.com/YLPn2luXsFQ",
                Img3=  "https://source.unsplash.com/9Y28PqKpwmw",
                Img4=  "https://source.unsplash.com/2on7yENo3P8",
                Time=  "60", // minutos
                UserId= 3,
                Like=  310,
                DontLike=  13
            },
            new Recipe{
                Id= 30,
                Title=  "Samosas",
                Description=  "Empanadas fritas rellenas de carne especiada o verduras.",
                MainImage=  "https://source.unsplash.com/6MfyD9WQeFQ",
                Img2=  "https://source.unsplash.com/Rd_0zJpZmIk",
                Img3=  "https://source.unsplash.com/kPjpNjqkF6Q",
                Img4=  "https://source.unsplash.com/EZf0EdscvX8",
                Time=  "45", // minutos
                UserId= 3,
                Like=  370,
                DontLike=  15
            },
            new Recipe{
                Id= 31,
                Title=  "Pavlova",
                Description=  "Postre merengue con una capa crujiente y un relleno de crema y frutas.",
                MainImage=  "https://source.unsplash.com/_27RJh6k0J4",
                Img2=  "https://source.unsplash.com/xhD1_xixmtY",
                Img3=  "https://source.unsplash.com/QI4pHqK3UtM",
                Img4=  "https://source.unsplash.com/Th3Yh-KwQOg",
                Time=  "90", // minutos
                UserId= 1,
                Like=  490,
                DontLike=  17
            },
            new Recipe{
                Id= 32,
                Title=  "Sopa de Tomate",
                Description=  "Sopa ligera de tomate con un toque de albahaca y crema.",
                MainImage=  "https://source.unsplash.com/RgqL5PaZ_Xc",
                Img2=  "https://source.unsplash.com/X4zo8IhDp3Q",
                Img3=  "https://source.unsplash.com/7cD_LrYjSO4",
                Img4=  "https://source.unsplash.com/3o4cptxUpKE",
                Time=  "30", // minutos
                UserId= 3,
                Like=  330,
                DontLike=  12
            },
            new Recipe{
                Id= 33,
                Title=  "Canelones de Espinacas",
                Description=  "Pasta rellena de espinacas y ricotta, cubiertos con salsa de tomate.",
                MainImage=  "https://source.unsplash.com/aW2geMsF7Hk",
                Img2=  "https://source.unsplash.com/IQajmGJ3Y1I",
                Img3=  "https://source.unsplash.com/Oa5osAVo-Xg",
                Img4=  "https://source.unsplash.com/RYGzLXfNfJY",
                Time=  "55", // minutos
                UserId= 3,
                Like=  290,
                DontLike=  10
            },
            new Recipe{
                Id= 34,
                Title=  "Bruschetta",
                Description=  "Rebanadas de pan tostado con tomate, albahaca y ajo.",
                MainImage=  "https://source.unsplash.com/5PqAO_7T4Eo",
                Img2=  "https://source.unsplash.com/oE_5L04V7N8",
                Img3=  "https://source.unsplash.com/ZQmpmLsU9iI",
                Img4=  "https://source.unsplash.com/1rMN7C2l6ZQ",
                Time=  "15", // minutos
                UserId= 4,
                Like=  410,
                DontLike=  5
            },
            new Recipe{
                Id= 35,
                Title=  "Croquetas de Jamón",
                Description=  "Deliciosas croquetas rellenas de jamón y bechamel.",
                MainImage=  "https://source.unsplash.com/Ochd6bfgkKY",
                Img2=  "https://source.unsplash.com/4eJlH9nWoxg",
                Img3=  "https://source.unsplash.com/Ef2LVsYLpc8",
                Img4=  "https://source.unsplash.com/T_x8zKw_su4",
                Time=  "40", // minutos
                UserId= 5,
                Like=  355,
                DontLike=  11
            },
            new Recipe{
                Id= 36,
                Title=  "Ensalada Caprese",
                Description=  "Ensalada con tomate, mozzarella y albahaca, aderezada con aceite de oliva.",
                MainImage=  "https://source.unsplash.com/jP5j5i68fHI",
                Img2=  "https://source.unsplash.com/4otEN6V9KYY",
                Img3=  "https://source.unsplash.com/DRD8YUL9R3s",
                Img4=  "https://source.unsplash.com/QxSEk_hLu1g",
                Time=  "20", // minutos
                UserId= 6,
                Like=  360,
                DontLike=  7
            },
            new Recipe{
                Id= 37,
                Title=  "Pollo al Ajillo",
                Description=  "Pollo cocido con ajo y perejil, un plato lleno de sabor.",
                MainImage=  "https://source.unsplash.com/TmGm2yxu-w8",
                Img2=  "https://source.unsplash.com/7pJnbHYD5mQ",
                Img3=  "https://source.unsplash.com/E_dK6KlbEec",
                Img4=  "https://source.unsplash.com/ik7W2p5rXwM",
                Time=  "45", // minutos
                UserId= 3,
                Like=  290,
                DontLike=  12
            },
            new Recipe{
                Id= 38,
                Title=  "Tarta de Queso",
                Description=  "Postre cremoso y suave a base de queso crema y una base de galleta.",
                MainImage=  "https://source.unsplash.com/kzD9g_t-w6I",
                Img2=  "https://source.unsplash.com/K_3DBa4lA2A",
                Img3=  "https://source.unsplash.com/E5J5V2_mZ1A",
                Img4=  "https://source.unsplash.com/BqD8RBxOqps",
                Time=  "50", // minutos
                UserId= 2,
                Like=  350,
                DontLike=  14
            },
            new Recipe{
                Id= 39,
                Title=  "Burritos",
                Description=  "Tortillas rellenas de carne, frijoles y arroz, con salsa picante.",
                MainImage=  "https://source.unsplash.com/BhGbV6p0IP4",
                Img2=  "https://source.unsplash.com/sTXXtmt5E8E",
                Img3=  "https://source.unsplash.com/4L3Kx3Q22Nc",
                Img4=  "https://source.unsplash.com/KYcquy4ay9I",
                Time=  "40", // minutos
                UserId= 1,
                Like=  370,
                DontLike=  11
            },
            new Recipe{
                Id= 40,
                Title=  "Tacos al Pastor",
                Description=  "Tacos de cerdo marinado con salsa de piña y especias.",
                MainImage=  "https://source.unsplash.com/4DA0XeWTwzo",
                Img2=  "https://source.unsplash.com/X6eEDE5LZtk",
                Img3=  "https://source.unsplash.com/ulK8xQ_eEws",
                Img4=  "https://source.unsplash.com/DpR7d4JhVX8",
                Time=  "30", // minutos
                UserId= 5,
                Like=  420,
                DontLike=  13
            }
        };

        #endregion
        public List<RecipesListDTO> GetAll(int? order)
        {
            List<RecipesListDTO> ListRecipes = new List<RecipesListDTO>();

            foreach (var item in list)
            {
                var recipe = new RecipesListDTO()
                {
                    Id = item.Id,
                    Title = item.Title,
                    MainImage = item.MainImage,
                    Time = item.Time + " Min",
                    Username =  "By " + _userService.GetUser(item.UserId).Username,
                    Like = item.Like,
                    dontLike = item.DontLike,
                    TimeToCompare = item.Time
                };

                ListRecipes.Add(recipe);
            }

            if (order == 1) { ListRecipes.Sort((y, x) => x.Like.CompareTo(y.Like)); } // ORDEN DE MAS A MENOS LIKES
            if (order == 2) { ListRecipes.Sort((x, y) => x.Like.CompareTo(y.Like)); } // ORDEN DE MENOS A MAS LIKES
            if (order == 3) { ListRecipes.Sort((y, x) => x.TimeToCompare.CompareTo(y.TimeToCompare)); } // ORDEN DE MAS A MENOS TIEMPO
            if (order == 4) { ListRecipes.Sort((x, y) => x.TimeToCompare.CompareTo(y.TimeToCompare)); } // ORDEN DE MENOS A MAS TIEMPO

            return ListRecipes;
        }
        public RecipeDTO GetRecipe(int id)
        {
            foreach (var item in list)
            {
                if (item.Id == id)
                {
                    //RecipeDTO recipe = new RecipeDTO()
                    //{
                    //    Id = item.Id,
                    //    Title = item.Title,
                    //    Description = item.Description,
                    //    ListIngredients = _ingredientService.GetIngredients(item.Id),
                    //    ListSteps = _stepService.GetSteps(item.Id),
                    //    MainImage = item.MainImage,
                    //    Img2 = item.Img2,
                    //    Img3 = item.Img3,
                    //    Img4 = item.Img4,
                    //    Time = item.Time + " Min",
                    //    Username = "By " + _userService.GetUser(item.UserId).Username,
                    //    Like = item.Like,
                    //    dontLike = item.DontLike,
                    //    CommentList = _commentService.GetComments(item.Id),
                    //};

                    return _helperService.GetRecipeDTO(item);
                }
            }

            return null;
        }
        public List<RecipesListDTO> GetRecipesByUser(int userId) {
            List<RecipesListDTO> listRecipes = new List<RecipesListDTO>();

            foreach (var item in list)
            {
                if (item.UserId == userId)
                {
                    RecipesListDTO recipe = new RecipesListDTO()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        MainImage = item.MainImage,
                        Time = item.Time + " Min",
                        Username = "By " + _userService.GetUser(item.UserId).Username,
                        Like = item.Like,
                        dontLike = item.DontLike
                    };

                    listRecipes.Add(recipe);
                }

            }
            return listRecipes;
        }
        public List<RecipesListDTO> GetFavsUser(List<Fav> favList)
        {
            List<RecipesListDTO> ListFav = new List<RecipesListDTO>();

            foreach (var item in list)
            {
                foreach (var fav in favList)
                {
                    if (item.Id == fav.RecipeId)
                    {
                        var recipe = new RecipesListDTO()
                        {
                            Id = item.Id,
                            Title = item.Title,
                            MainImage = item.MainImage,
                            Time = item.Time + " Min",
                            Username = "By " + _userService.GetUser(item.UserId).Username,
                            Like = item.Like,
                            dontLike = item.DontLike,
                            TimeToCompare = item.Time
                        };

                        ListFav.Add(recipe);
                    }
                }
            }

            return ListFav;
        }
    }
}
