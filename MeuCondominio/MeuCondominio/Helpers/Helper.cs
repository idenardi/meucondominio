using MeuCondominio.Models;
using System;
using System.Collections.ObjectModel;

namespace MeuCondominio.Helpers
{
    public class Helper
    {
        public static string url = "https://meucondominio.azurewebsites.net";

        public static ObservableCollection<Notification> Notifications
        {
            get
            {
                return new ObservableCollection<Notification>()
                {
                    new Notification()
                    {
                        IsNew = true,
                        DateTimeSent = new DateTime(2018, 7, 2, 11, 20, 0),
                        Sender = "Gabriel Silva",
                        UserId = 1,
                        Type = Notification.NotificationType.Condominio
                    },
                    new Notification()
                    {
                        IsNew = true,
                        DateTimeSent = new DateTime(2018, 7, 3, 11, 20, 0),
                        Sender = "Gabriel Silva",
                        UserId = 1,
                        Type = Notification.NotificationType.Correspondencia
                    }
                };
            }
        }

        public static ObservableCollection<BoardMessage> BoardMessages
        {
            get
            {
                string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In consectetur dolor non dapibus gravida. Aenean nulla augue, ";
                text += "porta viverra fringilla et, sollicitudin ac leo. Duis id tempor neque, suscipit egestas mi. Duis quis sollicitudin lectus. ";
                text += "Curabitur ut gravida mauris, ut feugiat lectus. Phasellus venenatis sit amet nunc in ullamcorper.";

                return new ObservableCollection<BoardMessage>()
                {
                    new BoardMessage()
                    {
                        DateTimeSent = new DateTime(2018, 7, 2, 11, 20, 0),
                        Sender = "Gabriel Silva",
                        UserId = 1,
                        Content = text,
                        User = Services.UserService.GetUser(1)
                    },
                    new BoardMessage()
                    {
                        DateTimeSent = new DateTime(2018, 7, 3, 11, 20, 0),
                        Sender = "Gabriel Silva",
                        UserId = 1,
                        Content = "nteger ac varius erat, at dictum erat. Nunc non sem at sem sagittis commodo non ut metus. Aliquam venenatis tortor nec lacus lacinia vestibulum.",
                        User = Services.UserService.GetUser(1)
                    }
                };
            }
        }
    }
}
