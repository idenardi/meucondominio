using MeuCondominio.Models;
using MeuCondominio.Services;
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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
            BindingContext = UserService.GetUser();
			InitializeComponent();
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("user");
            var page = new NavigationPage(new LoginPage());
            App.Current.MainPage = page;
        }
    }
}