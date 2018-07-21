using MeuCondominio.Helpers;
using MeuCondominio.Services.AzureModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeuCondominio.Services
{
    public class AzureService
    {
        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            if (Client == null)
                Client = new MobileServiceClient(Helper.url);
        }

        public async Task<IEnumerable<Notification>> ListAllNotificationsAsync(int userID)
        {
            Initialize();
            return await Client.GetTable<Notification>().Where(x => x.user == userID).ToListAsync();
        }

        public async Task<Notification> SaveNotificationAsync(Notification notification)
        {
            try
            {
                Initialize();

                if(!string.IsNullOrEmpty(notification.Id))
                    await Client.GetTable<Notification>().UpdateAsync(notification);    
                else
                    await Client.GetTable<Notification>().InsertAsync(notification);
                return notification;
            }
            catch
            {
                System.Diagnostics.Debugger.Break();
            }
            return null;
        }

        public async Task<IEnumerable<Messages>> ListAllMessagesAsync()
        {
            Initialize();
            return await Client.GetTable<Messages>().ToListAsync();
        }

        public async Task<Messages> CreateMessageAsync(Messages message)
        {
            try
            {
                Initialize();
                await Client.GetTable<Messages>().InsertAsync(message);
                return message;
            }
            catch
            {
                System.Diagnostics.Debugger.Break();
            }
            return null;
        }
    }
}
