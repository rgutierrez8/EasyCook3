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
        public List<StepDTO> GetSteps(int recipeId)
        {
            List<StepDTO> list = new List<StepDTO>();

            //foreach(var item in steps)
            //{
            //    if(item.RecipeId == recipeId)
            //    {
            //        StepDTO step = new StepDTO()
            //        {
            //            NumberStep = item.NumberStep,
            //            Describe = item.Description,
            //        };

            //        list.Add(step);
            //    }
            //}

            return list;    
        }
    }
}
