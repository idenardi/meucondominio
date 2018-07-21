using System;

namespace MeuCondominio.Models
{
    public class SendNotification: MvvmHelpers.ObservableObject
    {
        public string Tipo { get; set; }
        public DateTime Sent { get; set; }
        public string Text { get; set; }
        public MvvmHelpers.ObservableRangeCollection<Place> lstPlaces { get; set; }
    }
}
