using MeuCondominio.Services;
using MeuCondominio.ViewModels;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MeuCondominio
{
    public static class ViewModelLocator
    {
        static NotificationsViewModel notificationsVM;
        public static NotificationsViewModel NotificationsViewModel
            => notificationsVM ?? (notificationsVM = new NotificationsViewModel());
    }


	public partial class App : Application
	{
		public App ()
		{
            // Initialize Live Reload.
#if DEBUG
            LiveReload.Init();
#endif

            InitializeComponent();

            OnInitialize();
		}

        private void OnInitialize()
        {
            var sUsuario = UserService.GetUser();

            if (sUsuario == null)
                MainPage = new NavigationPage(new LoginPage());
            else
                MainPage = new NavigationPage(new MainPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
