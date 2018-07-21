using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MeuCondominio.Models
{
    public class BoardMessage
    {
        public int UserId { get; set; }
        public DateTime DateTimeSent { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }

        public User User { get; set; }

        public string Created
        {
            get
            {
                return DateTimeSent.ToString("dd/MM/yyyy hh:mm") + " - " + Sender;
            }
        }
    }
}
