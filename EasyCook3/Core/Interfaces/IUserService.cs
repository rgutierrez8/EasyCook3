using EasyCook3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core.Interfaces
{
    public interface IUserService
    {
        public User GetUser(int id);
        public int GetId(string username);  
    }
}
