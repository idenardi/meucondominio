using MeuCondominio.Models;
using MeuCondominio.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeuCondominio.ViewModels
{
    public class BoardViewModel : MvvmHelpers.ObservableObject
    {
        private List<BoardMessage> _BoardMessages;
        public List<BoardMessage> BoardMessages
        {
            get { return _BoardMessages; }
            set { SetProperty(ref _BoardMessages, value); }
        }

        public async Task LoadMessages()
        {
            var lst = await new AzureService().ListAllMessagesAsync();
            var lstMessages = new List<Models.BoardMessage>();

            foreach (var msg in lst)
            {
                lstMessages.Add(new BoardMessage()
                {
                    Content = msg.Content,
                    DateTimeSent = msg.Sent,
                    Sender = msg.Sender,
                    UserId = msg.User,
                    User = UserService.GetUser(msg.User)
                });
            }

            BoardMessages = lstMessages;
        }
    }
}
