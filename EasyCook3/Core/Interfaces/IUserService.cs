using EasyCook3.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUser();
        int GetId(string username);
        Task<HttpStatusCode> NewUser(NewUserDTO user);
    }
}
