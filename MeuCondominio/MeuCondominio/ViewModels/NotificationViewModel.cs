using MeuCondominio.Helpers;
using MeuCondominio.Models;
using MeuCondominio.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MeuCondominio.ViewModels
{
    public class NotificationsViewModel : MvvmHelpers.ObservableObject
    {
        private List<Notification> _Notifications;
        public List<Notification> Notifications
        {
            get { return _Notifications; }
            set { SetProperty(ref _Notifications, value); }
        }

        public async Task LoadNotifications()
        {
            Notifications = await NotificationService.GetNotifications(UserService.GetUser().UserId);
        }
    }
}
