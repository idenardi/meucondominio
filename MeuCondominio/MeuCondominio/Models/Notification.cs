using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MeuCondominio.Models
{
    public class Notification
    {
        public enum NotificationType
        {
            Correspondencia = 0,
            Sedex = 1,
            Condominio = 2
        }

        public int UserId { get; set; }
        public DateTime DateTimeSent { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }
        public bool IsNew { get; set; }
        public NotificationType Type { get; set; }


        public string NotificationText
        {
            get 
            {
                string sText = Text;

                if (!string.IsNullOrEmpty(sText))
                    return sText;

                switch (Type)
                {
                    case NotificationType.Correspondencia:
                        sText = "Correspondência chegou";
                        break;
                    case NotificationType.Sedex:
                        sText = "Sedex chegou";
                        break;
                    case NotificationType.Condominio:
                        sText = "Condomínio chegou";
                        break;
                    default:
                        sText = "Correspondência";
                        break;
                }

                return sText;
            }
        }


        public string NotificationImage
        {
            get
            {
                string sImage = "mail2.png";
                switch (Type)
                {
                    case NotificationType.Correspondencia:
                        sImage = "mail2.png";
                        break;
                    case NotificationType.Sedex:
                        sImage = "box.png";
                        break;
                    case NotificationType.Condominio:
                        sImage = "invoice.png";
                        break;
                    default:
                        sImage = "mail2.png";
                        break;
                }

                if (Device.RuntimePlatform == Device.UWP)
                    sImage = "images//" + sImage;

                return sImage;
            }
        }
    }
}
