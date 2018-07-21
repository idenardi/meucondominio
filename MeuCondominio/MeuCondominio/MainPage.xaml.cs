using MeuCondominio.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace MeuCondominio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage ()
        {
            InitializeComponent();

            var user = UserService.GetUser();

            this.Children.Add(new BoardPage());

            if (user.IsMorador)
                this.Children.Add(new NotificationPage());
            else
                this.Children.Add(new SendNotificationPage());

            this.Children.Add(new ProfilePage());

            this.Children[0].Icon = "ic_forum_white_24dp.png";
            this.Children[1].Icon = "ic_notifications_white_24dp.png";
            this.Children[2].Icon = "ic_person_white_24dp.png";
        }

        private void TabbedPage_CurrentPageChanged(object sender, System.EventArgs e)
        {
            var i = this.Children.IndexOf(this.CurrentPage);

            switch (i)
            {
                case 0:
                    Title = "Mural";
                    break;
                case 1:
                    Title = "Notificações";
                    break;
                case 2:
                    Title = "Perfil";
                    break;
                default:
                    Title = "Meu Condomínio";
                    break;
            }
        }
    }
}