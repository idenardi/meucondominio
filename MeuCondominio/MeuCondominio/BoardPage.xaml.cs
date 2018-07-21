
using Acr.UserDialogs;
using MeuCondominio.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeuCondominio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BoardPage : ContentPage
	{
        ViewModels.BoardViewModel vm;

		public BoardPage ()
		{
			InitializeComponent();
            vm = new ViewModels.BoardViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            using (UserDialogs.Instance.Loading("Carregando..."))
            {
                await vm.LoadMessages();
            }
        }

        private async void btnSend_Clicked(object sender, System.EventArgs e)
        {
            if(txtMessage.Text.Trim() == "")
            {
                await App.Current.MainPage.DisplayAlert("Nada foi enviado", "Mensagem não pode estar em branco", "OK");
                return;
            }

            var user = UserService.GetUser();
            var msg = new Models.BoardMessage()
            {
                Content = txtMessage.Text,
                DateTimeSent = DateTime.Now,
                Sender = user.Name,
                UserId = user.UserId
            };

            await BoardService.NewMessage(msg);
            txtMessage.Text = "";

            using (UserDialogs.Instance.Loading("Carregando..."))
            {
                await vm.LoadMessages();
            }

        }

        private async void lvMessages_Refreshing(object sender, System.EventArgs e)
        {
            await vm.LoadMessages();
            lvMessages.IsRefreshing = false;
        }
    }
}