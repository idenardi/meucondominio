using MeuCondominio.Services;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeuCondominio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            string sUser = "gsilva";

            if (!string.IsNullOrEmpty(txtUser.Text))
                sUser = txtUser.Text;

            var user = UserService.GetUser(sUser);
            if (user != null)
            {
                Preferences.Remove("user");
                Preferences.Set("user", user.Login);

                var navigatePage = new NavigationPage(new MainPage());
                App.Current.MainPage = navigatePage;
            }
            else
                CrossToastPopUp.Current.ShowToastMessage("Usuario e/ou senha inválido(s)");
        }

        private void TxtPolicy_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new PrivacyPage());
        }
    }
}