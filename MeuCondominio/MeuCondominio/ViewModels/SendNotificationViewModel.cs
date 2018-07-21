using MeuCondominio.Models;
using MeuCondominio.Services;
using System;

namespace MeuCondominio.ViewModels
{
    public class SendNotificationViewModel : MvvmHelpers.ObservableObject
    {
        public SendNotification Notification { get; set; }

        public SendNotificationViewModel()
        {
            var temp = new SendNotification();
            temp.lstPlaces = PlaceService.GetPlaces();
            temp.Sent = DateTime.Now;
            Notification = temp;
        }
    }
}
