using System;
using System.Collections.Generic;
using System.Text;

namespace MeuCondominio.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public string ProfileImage { get; set; }
        public string Name { get; set; }

        public string Block { get; set; }
        public string Apartment { get; set; }

        public bool IsMessenger { get; set; }
        public bool IsMorador { get; set; }


        public bool HasApartment
        {
            get
            {
                return (!string.IsNullOrEmpty(Block) && !string.IsNullOrEmpty(Apartment));
            }
        }

        public string TipoUsuario
        {
            get
            {
                return (IsMorador ? "Morador" : "Portaria");
            }
        }
    }
}
