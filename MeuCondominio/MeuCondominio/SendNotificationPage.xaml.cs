using MeuCondominio.ViewModels;
using MeuCondominio.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System;
using MeuCondominio.Services;
using Acr.UserDialogs;

namespace MeuCondominio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SendNotificationPage : ContentPage
	{
        SendNotificationViewModel vm;

		public SendNotificationPage()
		{
            vm = new SendNotificationViewModel();
            BindingContext = vm;
            InitializeComponent();
		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var isSelected = ((Models.Place)((ListView)sender).SelectedItem).IsSelected;
            ((Models.Place)((ListView)sender).SelectedItem).IsSelected = !isSelected;
        }

        private List<Notification> Valida(out string sErro)
        {
            List<Notification> lst = new List<Notification>();
            sErro = string.Empty;

            if (pcTipo.SelectedItem == null || pcTipo.SelectedItem.ToString() == "")
                sErro = "Tipo de notificação não selecionada";

            if (!vm.Notification.lstPlaces.Any(x => x.IsSelected))
                sErro = "Nenhum apartamento selecionado";

            if (!string.IsNullOrEmpty(sErro))
                return null;

            var user = UserService.GetUser();

            foreach (var place in vm.Notification.lstPlaces.Where(x=> x.IsSelected))
            {
                var temp = new Notification()
                {
                    DateTimeSent = DateTime.Now,
                    IsNew = true,
                    Text = vm.Notification.Text,
                    Type = (Notification.NotificationType)Enum.Parse(typeof(Notification.NotificationType), pcTipo.SelectedItem.ToString()),
                    Sender = user.Name,
                    UserId = UserService.GetId(place.Block, place.Number)
                };

                lst.Add(temp);
            }

            return lst;
        }

        private async void btnEnviar_Clicked(object sender, System.EventArgs e)
        {
            bool bErro = false;
            string sErro = string.Empty;

            using (UserDialogs.Instance.Loading("Enviando..."))
            {
                var lst = Valida(out sErro);

                if (lst == null)
                    bErro = true;
                else
                    await NotificationService.SendNotification(lst);
            }

            if (bErro)
            {
                await App.Current.MainPage.DisplayAlert("Nada foi enviado", sErro, "OK");
                return;
            }
            await App.Current.MainPage.DisplayAlert("Sucesso", "Notificações enviadas!", "OK");

            vm = new SendNotificationViewModel();

            // reinicia campos
            pcTipo.SelectedItem = null;
            txtText.Text = "";
            BindingContext = vm;

        }
    }
}