using MeuCondominio.Helpers;
using MeuCondominio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MeuCondominio.Services
{
    public class NotificationService
    {
        public static async Task<List<Notification>> GetNotifications(int userId)
        {
            var az = new AzureService();
            var lst = new List<Notification>();

            var lstAzure = await az.ListAllNotificationsAsync(userId);

            foreach (var item in lstAzure)
            {
                lst.Add(new Notification()
                {
                    DateTimeSent = item.Sent,
                    IsNew = item.IsNew,
                    Sender = item.Sender,
                    Text = item.Text,
                    Type = (Notification.NotificationType)item.Tipo,
                    UserId = item.user
                });
            }

            return lst;
        }


        public static async Task SendNotification(List<Notification> lstNotification)
        {
            var az = new AzureService();

            foreach (var item in lstNotification)
            {
                AzureModels.Notification notification = new AzureModels.Notification()
                {
                    IsNew = true,
                    Sender = item.Sender,
                    Sent = item.DateTimeSent,
                    Text = item.Text,
                    Tipo = (int)item.Type,
                    user = item.UserId
                };

                await az.SaveNotificationAsync(notification);
            }

        }
    }
}
