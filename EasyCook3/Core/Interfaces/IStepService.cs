using EasyCook3.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core.Interfaces
{
    public interface IStepService
    {
        public List<StepDTO> GetSteps(int recipeId);
    }
}
