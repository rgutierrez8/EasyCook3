using EasyCook3.Core.Interfaces;
using EasyCook3.Models.DTO;
using EasyCook3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core
{
    public class StepService : IStepService
    {

        #region LISTA DE  PASOS GENERICA

        List<Step> steps = new List<Step>
        {
            // Receta 1
            new Step { Id = 1, RecipeId = 1, NumberStep = 1, Description = "Picar la cebolla y el ajo finamente." },
            new Step { Id = 2, RecipeId = 1, NumberStep = 2, Description = "Calentar el aceite en una sartén y sofreír la cebolla y el ajo hasta que estén dorados." },
            new Step { Id = 3, RecipeId = 1, NumberStep = 3, Description = "Agregar los tomates y cocinar por 10 minutos." },
            new Step { Id = 4, RecipeId = 1, NumberStep = 4, Description = "Añadir sal y pimienta al gusto, y servir caliente." },

            // Receta 2
            new Step { Id = 5, RecipeId = 2, NumberStep = 1, Description = "Precalentar el horno a 180°C." },
            new Step { Id = 6, RecipeId = 2, NumberStep = 2, Description = "Mezclar la harina, azúcar y la mantequilla en un bol hasta obtener una masa homogénea." },
            new Step { Id = 7, RecipeId = 2, NumberStep = 3, Description = "Extender la masa en un molde para tarta y hornear por 25 minutos." },
            new Step { Id = 8, RecipeId = 2, NumberStep = 4, Description = "Dejar enfriar antes de rellenar con la mezcla de frutas." },

            // Receta 3
            new Step { Id = 9, RecipeId = 3, NumberStep = 1, Description = "Cortar las verduras en tiras." },
            new Step { Id = 10, RecipeId = 3, NumberStep = 2, Description = "Calentar el aceite en una sartén grande." },
            new Step { Id = 11, RecipeId = 3, NumberStep = 3, Description = "Sofreír las verduras hasta que estén tiernas." },
            new Step { Id = 12, RecipeId = 3, NumberStep = 4, Description = "Agregar el pollo y cocinar hasta que esté bien hecho." },

            // Receta 4
            new Step { Id = 13, RecipeId = 4, NumberStep = 1, Description = "Lavar y cortar las frutas en trozos pequeños." },
            new Step { Id = 14, RecipeId = 4, NumberStep = 2, Description = "Mezclar las frutas con el azúcar y el jugo de limón." },
            new Step { Id = 15, RecipeId = 4, NumberStep = 3, Description = "Dejar reposar en el refrigerador durante 2 horas antes de servir." },

            // Receta 5
            new Step { Id = 16, RecipeId = 5, NumberStep = 1, Description = "Precalentar el horno a 200°C." },
            new Step { Id = 17, RecipeId = 5, NumberStep = 2, Description = "Mezclar la harina con el polvo de hornear." },
            new Step { Id = 18, RecipeId = 5, NumberStep = 3, Description = "Agregar el azúcar y la mantequilla, y mezclar bien." },
            new Step { Id = 19, RecipeId = 5, NumberStep = 4, Description = "Formar pequeñas bolitas y colocarlas en una bandeja para hornear." },
            new Step { Id = 20, RecipeId = 5, NumberStep = 5, Description = "Hornear durante 12-15 minutos o hasta que estén doradas." },

            // Receta 6
            new Step { Id = 21, RecipeId = 6, NumberStep = 1, Description = "Enjuagar los frijoles y cocinarlos en una olla con agua por 1 hora." },
            new Step { Id = 22, RecipeId = 6, NumberStep = 2, Description = "En otra olla, calentar el aceite y añadir la cebolla y el ajo." },
            new Step { Id = 23, RecipeId = 6, NumberStep = 3, Description = "Sofreír hasta que estén dorados y luego añadir los tomates y las especias." },
            new Step { Id = 24, RecipeId = 6, NumberStep = 4, Description = "Añadir los frijoles cocidos y cocinar a fuego lento por 30 minutos." },

            // Receta 7
            new Step { Id = 25, RecipeId = 7, NumberStep = 1, Description = "Pelar y picar las zanahorias y las patatas en cubos." },
            new Step { Id = 26, RecipeId = 7, NumberStep = 2, Description = "Cocinar en agua con sal hasta que estén tiernas." },
            new Step { Id = 27, RecipeId = 7, NumberStep = 3, Description = "Escurrir y hacer puré con un poco de mantequilla y leche." },
            new Step { Id = 28, RecipeId = 7, NumberStep = 4, Description = "Servir caliente con el plato principal." },

            // Receta 8
            new Step { Id = 29, RecipeId = 8, NumberStep = 1, Description = "Picar finamente la cebolla, el ajo y el pimiento." },
            new Step { Id = 30, RecipeId = 8, NumberStep = 2, Description = "Sofreír en una sartén con aceite hasta que estén tiernos." },
            new Step { Id = 31, RecipeId = 8, NumberStep = 3, Description = "Agregar el arroz y cocinar por 5 minutos." },
            new Step { Id = 32, RecipeId = 8, NumberStep = 4, Description = "Añadir el caldo y cocinar a fuego lento hasta que el arroz esté hecho." },

            // Receta 9
            new Step { Id = 33, RecipeId = 9, NumberStep = 1, Description = "Precalentar el horno a 180°C." },
            new Step { Id = 34, RecipeId = 9, NumberStep = 2, Description = "Mezclar la harina, el azúcar y el cacao en un bol." },
            new Step { Id = 35, RecipeId = 9, NumberStep = 3, Description = "Agregar los huevos y la leche, y batir bien." },
            new Step { Id = 36, RecipeId = 9, NumberStep = 4, Description = "Verter la mezcla en un molde engrasado y hornear por 30 minutos." },

            // Receta 10
            new Step { Id = 37, RecipeId = 10, NumberStep = 1, Description = "Calentar el aceite en una sartén y añadir el ajo picado." },
            new Step { Id = 38, RecipeId = 10, NumberStep = 2, Description = "Sofreír el ajo hasta que esté dorado." },
            new Step { Id = 39, RecipeId = 10, NumberStep = 3, Description = "Agregar las gambas y cocinar hasta que estén rosadas." },
            new Step { Id = 40, RecipeId = 10, NumberStep = 4, Description = "Servir con arroz o pasta." },

            // Receta 11
            new Step { Id = 41, RecipeId = 11, NumberStep = 1, Description = "Cortar las berenjenas en rodajas y salarlas para eliminar el amargor." },
            new Step { Id = 42, RecipeId = 11, NumberStep = 2, Description = "Enjuagar y secar las berenjenas, luego empanizarlas y freírlas en aceite caliente." },
            new Step { Id = 43, RecipeId = 11, NumberStep = 3, Description = "Colocar las berenjenas fritas en una fuente para hornear y cubrir con salsa de tomate y queso." },
            new Step { Id = 44, RecipeId = 11, NumberStep = 4, Description = "Hornear a 180°C hasta que el queso se derrita y esté dorado." },

            // Receta 12
            new Step { Id = 45, RecipeId = 12, NumberStep = 1, Description = "Cocinar la pasta según las instrucciones del paquete." },
            new Step { Id = 46, RecipeId = 12, NumberStep = 2, Description = "En una sartén, calentar aceite y añadir el ajo y el tomate." },
            new Step { Id = 47, RecipeId = 12, NumberStep = 3, Description = "Sofreír hasta que el tomate se desintegre y añadir las aceitunas." },
            new Step { Id = 48, RecipeId = 12, NumberStep = 4, Description = "Mezclar con la pasta cocida y servir con queso rallado." },

            // Receta 13
            new Step { Id = 49, RecipeId = 13, NumberStep = 1, Description = "Lavar las espinacas y escurrir." },
            new Step { Id = 50, RecipeId = 13, NumberStep = 2, Description = "Sofreír el ajo en una sartén con aceite." },
            new Step { Id = 51, RecipeId = 13, NumberStep = 3, Description = "Agregar las espinacas y cocinar hasta que se marchiten." },
            new Step { Id = 52, RecipeId = 13, NumberStep = 4, Description = "Añadir sal y pimienta al gusto y servir caliente." },

            // Receta 14
            new Step { Id = 53, RecipeId = 14, NumberStep = 1, Description = "Picar los tomates y el pepino en cubos pequeños." },
            new Step { Id = 54, RecipeId = 14, NumberStep = 2, Description = "Mezclar con cebolla picada y aderezar con aceite de oliva y vinagre." },
            new Step { Id = 55, RecipeId = 14, NumberStep = 3, Description = "Añadir sal y pimienta al gusto y servir fresca." },

            // Receta 15
            new Step { Id = 56, RecipeId = 15, NumberStep = 1, Description = "Picar las papas en cubos pequeños y cocinarlas en agua con sal hasta que estén tiernas." },
            new Step { Id = 57, RecipeId = 15, NumberStep = 2, Description = "En una sartén, cocinar el tocino hasta que esté crujiente." },
            new Step { Id = 58, RecipeId = 15, NumberStep = 3, Description = "Mezclar las papas con el tocino y añadir cebolla verde picada." },
            new Step { Id = 59, RecipeId = 15, NumberStep = 4, Description = "Servir con aderezo al gusto." },

            // Receta 16
            new Step { Id = 60, RecipeId = 16, NumberStep = 1, Description = "Cortar el pollo en tiras y marinar con limón y especias." },
            new Step { Id = 61, RecipeId = 16, NumberStep = 2, Description = "Cocinar en una sartén con aceite hasta que esté dorado y cocido." },
            new Step { Id = 62, RecipeId = 16, NumberStep = 3, Description = "Servir con arroz o ensalada." },

            // Receta 17
            new Step { Id = 63, RecipeId = 17, NumberStep = 1, Description = "Precalentar el horno a 180°C." },
            new Step { Id = 64, RecipeId = 17, NumberStep = 2, Description = "Mezclar harina, azúcar y mantequilla hasta obtener una masa suave." },
            new Step { Id = 65, RecipeId = 17, NumberStep = 3, Description = "Formar bolitas de masa y colocarlas en una bandeja para hornear." },
            new Step { Id = 66, RecipeId = 17, NumberStep = 4, Description = "Hornear durante 10-12 minutos o hasta que estén doradas." },

            // Receta 18
            new Step { Id = 67, RecipeId = 18, NumberStep = 1, Description = "Lavar los champiñones y cortar en láminas." },
            new Step { Id = 68, RecipeId = 18, NumberStep = 2, Description = "Sofreír en una sartén con aceite y ajo hasta que estén dorados." },
            new Step { Id = 69, RecipeId = 18, NumberStep = 3, Description = "Añadir vino blanco y cocinar hasta que se evapore el alcohol." },
            new Step { Id = 70, RecipeId = 18, NumberStep = 4, Description = "Servir caliente con perejil picado." },

            // Receta 19
            new Step { Id = 71, RecipeId = 19, NumberStep = 1, Description = "Cortar las berenjenas en cubos y salarlas." },
            new Step { Id = 72, RecipeId = 19, NumberStep = 2, Description = "Enjuagar y secar las berenjenas, luego freír hasta que estén doradas." },
            new Step { Id = 73, RecipeId = 19, NumberStep = 3, Description = "Mezclar con salsa de tomate y queso rallado." },
            new Step { Id = 74, RecipeId = 19, NumberStep = 4, Description = "Hornear a 180°C hasta que el queso esté derretido." },

            // Receta 20
            new Step { Id = 75, RecipeId = 20, NumberStep = 1, Description = "Preparar una masa para pizza y estirarla en una bandeja para hornear." },
            new Step { Id = 76, RecipeId = 20, NumberStep = 2, Description = "Agregar salsa de tomate y esparcir uniformemente sobre la masa." },
            new Step { Id = 77, RecipeId = 20, NumberStep = 3, Description = "Cubrir con queso y los ingredientes de tu elección." },
            new Step { Id = 78, RecipeId = 20, NumberStep = 4, Description = "Hornear a 220°C durante 15-20 minutos o hasta que esté dorada." },

            // Receta 21
            new Step { Id = 79, RecipeId = 21, NumberStep = 1, Description = "Picar finamente la cebolla y el ajo." },
            new Step { Id = 80, RecipeId = 21, NumberStep = 2, Description = "Sofreír en una sartén con aceite hasta que estén dorados." },
            new Step { Id = 81, RecipeId = 21, NumberStep = 3, Description = "Añadir el tomate y cocinar a fuego lento por 20 minutos." },
            new Step { Id = 82, RecipeId = 21, NumberStep = 4, Description = "Servir con pan recién horneado." },

            // Receta 22
            new Step { Id = 83, RecipeId = 22, NumberStep = 1, Description = "Lavar y cortar las frutas en trozos." },
            new Step { Id = 84, RecipeId = 22, NumberStep = 2, Description = "Mezclar con yogur natural y miel." },
            new Step { Id = 85, RecipeId = 22, NumberStep = 3, Description = "Servir con nueces picadas por encima." },

            // Receta 23
            new Step { Id = 86, RecipeId = 23, NumberStep = 1, Description = "Preparar la masa de empanadas y rellenar con carne y cebolla." },
            new Step { Id = 87, RecipeId = 23, NumberStep = 2, Description = "Sellar las empanadas y colocarlas en una bandeja para hornear." },
            new Step { Id = 88, RecipeId = 23, NumberStep = 3, Description = "Hornear a 200°C por 20 minutos o hasta que estén doradas." },

            // Receta 24
            new Step { Id = 89, RecipeId = 24, NumberStep = 1, Description = "Marinar el pollo con jugo de limón y especias." },
            new Step { Id = 90, RecipeId = 24, NumberStep = 2, Description = "Cocinar en una parrilla hasta que esté dorado." },
            new Step { Id = 91, RecipeId = 24, NumberStep = 3, Description = "Servir con una ensalada fresca." },

            // Receta 25
            new Step { Id = 92, RecipeId = 25, NumberStep = 1, Description = "Preparar una mezcla de queso crema y hierbas." },
            new Step { Id = 93, RecipeId = 25, NumberStep = 2, Description = "Rellenar los pimientos con la mezcla de queso." },
            new Step { Id = 94, RecipeId = 25, NumberStep = 3, Description = "Hornear a 180°C por 15 minutos." },

            // Receta 26
            new Step { Id = 95, RecipeId = 26, NumberStep = 1, Description = "Preparar el batido con leche, frutas y miel." },
            new Step { Id = 96, RecipeId = 26, NumberStep = 2, Description = "Mezclar en una licuadora hasta obtener una textura suave." },
            new Step { Id = 97, RecipeId = 26, NumberStep = 3, Description = "Servir frío con hielo." },

            // Receta 27
            new Step { Id = 98, RecipeId = 27, NumberStep = 1, Description = "Cocer el arroz y reservar." },
            new Step { Id = 99, RecipeId = 27, NumberStep = 2, Description = "Sofreír el pollo con cebolla y especias." },
            new Step { Id = 100, RecipeId = 27, NumberStep = 3, Description = "Mezclar el pollo con el arroz y cocinar a fuego lento por 10 minutos." },

            // Receta 28
            new Step { Id = 101, RecipeId = 28, NumberStep = 1, Description = "Preparar una ensalada con tomate, pepino y aguacate." },
            new Step { Id = 102, RecipeId = 28, NumberStep = 2, Description = "Aderezar con aceite de oliva y limón." },
            new Step { Id = 103, RecipeId = 28, NumberStep = 3, Description = "Servir inmediatamente." },

            // Receta 29
            new Step { Id = 104, RecipeId = 29, NumberStep = 1, Description = "Preparar una mezcla de pan rallado y queso." },
            new Step { Id = 105, RecipeId = 29, NumberStep = 2, Description = "Empanar los filetes de pescado y freír en aceite caliente." },
            new Step { Id = 106, RecipeId = 29, NumberStep = 3, Description = "Servir con una salsa tártara." },

            // Receta 30
            new Step { Id = 107, RecipeId = 30, NumberStep = 1, Description = "Mezclar harina, levadura y agua hasta obtener una masa suave." },
            new Step { Id = 108, RecipeId = 30, NumberStep = 2, Description = "Dejar reposar durante 1 hora." },
            new Step { Id = 109, RecipeId = 30, NumberStep = 3, Description = "Amasar y formar panes, luego hornear a 220°C por 20 minutos." },

            // Receta 31
            new Step { Id = 110, RecipeId = 31, NumberStep = 1, Description = "Picar las verduras y sofreír con aceite." },
            new Step { Id = 111, RecipeId = 31, NumberStep = 2, Description = "Agregar el arroz y cocinar a fuego lento con caldo de verduras." },
            new Step { Id = 112, RecipeId = 31, NumberStep = 3, Description = "Servir caliente con hierbas frescas." },

            // Receta 32
            new Step { Id = 113, RecipeId = 32, NumberStep = 1, Description = "Cocinar la pasta al dente y escurrir." },
            new Step { Id = 114, RecipeId = 32, NumberStep = 2, Description = "Preparar una salsa con crema y queso." },
            new Step { Id = 115, RecipeId = 32, NumberStep = 3, Description = "Mezclar la pasta con la salsa y servir con queso rallado." },

            // Receta 33
            new Step { Id = 116, RecipeId = 33, NumberStep = 1, Description = "Cortar el pollo en tiras y marinar con especias." },
            new Step { Id = 117, RecipeId = 33, NumberStep = 2, Description = "Freír hasta que estén doradas y cocidas." },
            new Step { Id = 118, RecipeId = 33, NumberStep = 3, Description = "Servir con salsa de tu elección." },

            // Receta 34
            new Step { Id = 119, RecipeId = 34, NumberStep = 1, Description = "Mezclar harina, azúcar y levadura en un bol." },
            new Step { Id = 120, RecipeId = 34, NumberStep = 2, Description = "Agregar leche y huevos, y batir hasta obtener una masa suave." },
            new Step { Id = 121, RecipeId = 34, NumberStep = 3, Description = "Verter en moldes y hornear a 180°C por 25 minutos." },

            // Receta 35
            new Step { Id = 122, RecipeId = 35, NumberStep = 1, Description = "Preparar una salsa con cebolla, ajo y tomates." },
            new Step { Id = 123, RecipeId = 35, NumberStep = 2, Description = "Sofreír la salsa hasta que espese." },
            new Step { Id = 124, RecipeId = 35, NumberStep = 3, Description = "Servir con pasta o arroz." },

            // Receta 36
            new Step { Id = 125, RecipeId = 36, NumberStep = 1, Description = "Preparar la masa para crepas y cocinar en una sartén." },
            new Step { Id = 126, RecipeId = 36, NumberStep = 2, Description = "Rellenar con frutas y crema." },
            new Step { Id = 127, RecipeId = 36, NumberStep = 3, Description = "Enrollar y servir con sirope." },

            // Receta 37
            new Step { Id = 128, RecipeId = 37, NumberStep = 1, Description = "Mezclar harina, azúcar y mantequilla hasta obtener una textura arenosa." },
            new Step { Id = 129, RecipeId = 37, NumberStep = 2, Description = "Agregar huevo y mezclar hasta formar una masa." },
            new Step { Id = 130, RecipeId = 37, NumberStep = 3, Description = "Formar bolas y hornear a 180°C por 15 minutos." },

            // Receta 38
            new Step { Id = 131, RecipeId = 38, NumberStep = 1, Description = "Picar la cebolla y el ajo y sofreír en aceite." },
            new Step { Id = 132, RecipeId = 38, NumberStep = 2, Description = "Agregar carne y cocinar hasta que esté dorada." },
            new Step { Id = 133, RecipeId = 38, NumberStep = 3, Description = "Añadir salsa de tomate y cocinar a fuego lento." },

            // Receta 39
            new Step { Id = 134, RecipeId = 39, NumberStep = 1, Description = "Cortar las verduras en tiras y cocinarlas en una sartén con aceite." },
            new Step { Id = 135, RecipeId = 39, NumberStep = 2, Description = "Agregar tofu y cocinar hasta que esté dorado." },
            new Step { Id = 136, RecipeId = 39, NumberStep = 3, Description = "Servir con arroz." },

            // Receta 40
            new Step { Id = 137, RecipeId = 40, NumberStep = 1, Description = "Preparar una mezcla de queso crema y hierbas." },
            new Step { Id = 138, RecipeId = 40, NumberStep = 2, Description = "Rellenar los rollos de pan con la mezcla de queso." },
            new Step { Id = 139, RecipeId = 40, NumberStep = 3, Description = "Hornear a 200°C por 10 minutos o hasta dorar." },
        };


        #endregion
        public List<StepDTO> GetSteps(int recipeId)
        {
            List<StepDTO> list = new List<StepDTO>();

            foreach(var item in steps)
            {
                if(item.RecipeId == recipeId)
                {
                    StepDTO step = new StepDTO()
                    {
                        NumberStep = item.NumberStep,
                        Description = item.Description,
                    };

                    list.Add(step);
                }
            }

            return list;    
        }
    }
}
