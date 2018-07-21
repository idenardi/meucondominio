using System;
using System.Collections.Generic;
using System.Text;

namespace MeuCondominio.Services.AzureModels
{
    public class Messages
    {
        public string Id { get; set; }

        public DateTime Sent { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }

        public bool IsNew { get; set; }
        public int User { get; set; }
    }
}
