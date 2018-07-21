using MeuCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace MeuCondominio.Services
{
    public class UserService
    {

        public static List<User> GetAll()
        {
            return new List<User>()
            {
                new User()
                {
                    UserId = 1,
                    Login ="jmaria",
                    Name = "José Maria",
                    IsMessenger = false,
                    Password = "123456",
                    ProfileImage = "https://randomuser.me/api/portraits/men/3.jpg",
                    Apartment = "13",
                    Block = "A",
                    IsMorador = true
                },
                new User()
                {
                    UserId = 2,
                    Login ="gsilva",
                    Name = "Gabriel Silva",
                    IsMessenger = true,
                    Password = "123456",
                    ProfileImage = "https://randomuser.me/api/portraits/men/64.jpg",
                    Apartment = "",
                    Block = "",
                    IsMorador = false

                },
                new User()
                {
                    UserId = 3,
                    Login ="msantos",
                    Name = "Mônica Santos",
                    IsMessenger = false,
                    Password = "123456",
                    ProfileImage = "https://randomuser.me/api/portraits/women/3.jpg",
                    Apartment = "112",
                    Block = "A",
                    IsMorador = true
                }
            };
        }

        public static User GetUser(int UserId)
        {
            return GetAll().FirstOrDefault(u => u.UserId == UserId);
        }

        public static User GetUser(string UserLogin)
        {
            return GetAll().FirstOrDefault(u => u.Login == UserLogin);
        }

        public static int GetId(string bloco, string apto)
        {
            var user = GetAll().FirstOrDefault(x => x.Block.ToUpper() == bloco.ToUpper() && x.Apartment.ToUpper() == apto.ToUpper());
            return user == null ? 0 : user.UserId;
        }

        public static User GetUser()
        {
            string userLogin = Preferences.Get("user", "");
            return GetUser(userLogin);
        }
    }
}
