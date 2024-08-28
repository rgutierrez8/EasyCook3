using EasyCook3.Core.Interfaces;
using EasyCook3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCook3.Core
{
    public class UserService : IUserService
    {

        #region LISTA USUARIOS users

        List<User> users = new List<User>()
                {
                    new User{
                        Id= 1,
                        Name= "Ana",
                        LastName= "García",
                        Email= "ana.garcia@example.com",
                        Username= "ana_garcia92",
                        Password= "password123",
                        Pic= "https://randomuser.me/api/portraits/women/1.jpg",
                        Banner= "https://images.unsplash.com/photo-1506748686214-e9df14f21f3d?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=MnwzNjUyOXwwfDF8c2VhcmNofDJ8fGdlbnRzJTIwbGFuZGJhcmt8ZW58MHx8fDE2NTIxOTI1MjE&ixlib=rb-1.2.1&q=80&w=1600"
                    },
                    new User{
                        Id= 2,
                        Name= "Luis",
                        LastName= "Martínez",
                        Email= "luis.martinez@example.com",
                        Username= "luis_martinez87",
                        Password= "securepass456",
                        Pic= "https://randomuser.me/api/portraits/men/2.jpg",
                        Banner= "https://images.unsplash.com/photo-1485146712681-86f9d4d53a6e?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=MnwzNjUyOXwwfDF8c2VhcmNofDJ8fGdlbnRzJTIwY2l0eXxlbnwwfHx8fDE2NTIxOTI1MjE&ixlib=rb-1.2.1&q=80&w=1600"
                    },
                    new User{
                        Id= 3,
                        Name= "Marta",
                        LastName= "Rodríguez",
                        Email= "marta.rodriguez@example.com",
                        Username= "marta_rodriguez78",
                        Password= "password789",
                        Pic= "https://randomuser.me/api/portraits/women/3.jpg",
                        Banner= "https://images.unsplash.com/photo-1506748686214-5b4e2d6eaf8f?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=MnwzNjUyOXwwfDF8c2VhcmNofDkzfGdlbnRzJTIwbmF0dXJlJTIwYW5kJTIwZm9yZXN0fGVufDB8fHx8MTY0NTk0NzEwOQ&ixlib=rb-1.2.1&q=80&w=1600"
                    },
                    new User{
                        Id= 4,
                        Name= "Javier",
                        LastName= "Fernández",
                        Email= "javier.fernandez@example.com",
                        Username= "javier_fernandez96",
                        Password= "mypassword321",
                        Pic= "https://randomuser.me/api/portraits/men/4.jpg",
                        Banner= "https://images.unsplash.com/photo-1485564832427-e82b0740698d?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=MnwzNjUyOXwwfDF8c2VhcmNofDJ8fGdlbnRzJTIwZGVzZXJ0fGVufDB8fHx8MTY0NTk0NzEwOQ&ixlib=rb-1.2.1&q=80&w=1600"
                    },
                    new User{
                        Id= 5,
                        Name= "Sofía",
                        LastName= "Pérez",
                        Email= "sofia.perez@example.com",
                        Username= "sofia_perez88",
                        Password= "pass1234word",
                        Pic= "https://randomuser.me/api/portraits/women/5.jpg",
                        Banner= "https://images.unsplash.com/photo-1495574732540-6c1d0879fc51?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=MnwzNjUyOXwwfDF8c2VhcmNofDJ8fGdlbnRzJTIwYmVhY2h8ZW58MHx8fDE2NTIxOTI1MjE&ixlib=rb-1.2.1&q=80&w=1600"
                    },
                    new User() {
                        Id = 6,
                        Name = "Ramón",
                        LastName = "Gutierrez",
                        Email = "ramongutierrez523@gmail.com",
                        Username = "winnions",
                        Password = "password",
                        Pic = "https://media.licdn.com/dms/image/C4E03AQEhU8QGQ2K6Bw/profile-displayphoto-shrink_800_800/0/1623398632342?e=1729123200&v=beta&t=wAn-Bjj0-wLdSuXQEZh2-Xdk8Qk4kTLCaOXdTrEsybs",
                    }
                };

            #endregion
        public User GetUser(int id)
        {

            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    var data = new User
                    {
                        Id = user.Id,
                        Name = user.Name,
                        LastName = user.Name,
                        Email = user.Email,
                        Username = user.Username,
                        Password = user.Password,
                        Pic = user.Pic,
                        Banner = user.Banner,
                    };
                    return data;
                }
            }

            return null;
        }
        public int GetId(string username)
        {
            foreach(var user in users)
            {
                if(user.Username == username)
                {
                    return user.Id;
                }
            }

            return -1;
        }
    }
}
