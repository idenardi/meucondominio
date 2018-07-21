using MeuCondominio.Helpers;
using MeuCondominio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MeuCondominio.Services
{
    public class BoardService
    {
        public static List<BoardMessage> GetMessages()
        {
            var lst = Helper.BoardMessages.OrderByDescending(n => n.DateTimeSent).ToList();

            return lst;
        }

        public async static Task NewMessage(Models.BoardMessage newMessage)
        {
            var az = new AzureService();

            AzureModels.Messages msg = new AzureModels.Messages()
            {
                IsNew = true,
                Sender = newMessage.Sender,
                Content = newMessage.Content,
                Sent = newMessage.DateTimeSent,
                User = newMessage.UserId
            };

            await az.CreateMessageAsync(msg);
        }
    }
}
