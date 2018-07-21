using System;
using System.Collections.Generic;
using System.Text;

namespace MeuCondominio.Services.AzureModels
{
    public class Notification
    {
        public string Id { get; set; }
        public int Tipo { get; set; }

        public DateTime Sent { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }

        public bool IsNew { get; set; }
        public int user { get; set; }
    }
}
