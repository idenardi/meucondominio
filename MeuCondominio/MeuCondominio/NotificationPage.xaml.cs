
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeuCondominio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotificationPage : ContentPage
	{
        ViewModels.NotificationsViewModel vm;
		public NotificationPage()
		{
			InitializeComponent();
            vm = new ViewModels.NotificationsViewModel();
            BindingContext = vm;
        }

        private async void ListView_Refreshing(object sender, System.EventArgs e)
        {
            await vm.LoadNotifications();            
            lvNotification.IsRefreshing = false;
        }

        protected async override void OnAppearing()
        {
            using (UserDialogs.Instance.Loading("Carregando..."))
            {
                await vm.LoadNotifications();
            }
        }
    }
}