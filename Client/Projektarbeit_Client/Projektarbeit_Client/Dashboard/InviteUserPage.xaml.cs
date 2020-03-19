using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;

using Projektarbeit_Client.TCP;

namespace Projektarbeit_Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InviteUserPage : ContentPage
    {
        public InviteUserPage()
        {
            InitializeComponent();

            btn_back.Clicked += Btn_back_Clicked;
            btn_invite.Clicked += Btn_invite_Clicked;
        }

        private void Btn_invite_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("Keine Verbindung Möglich", "Bitte stellen sie sicher das sie mit dem Internet verbunden sind", "OK");
                return;
            }
            if (txt_email.Text == null)
            {
                DisplayAlert("Fehler", "Bitte füllen sie alle Felder aus", "OK");
                return;
            }

            switch (TCPCommandManager.SendInvite(txt_email.Text))
            {
                case 201:
                    Navigation.PushAsync(new ControllPanel());
                    Navigation.RemovePage(this);
                    DisplayAlert("Erfolgreich", "Du hast jemanden Eingeladen", "OK");
                    break;
                default:
                    DisplayAlert("Fehler", "Die Einladung ist Fehlgeschlagen überprüfe bitte die E-Mail", "OK");
                    break;
            }
        }

        private void Btn_back_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ControllPanel());
            Navigation.RemovePage(this); 
        }
    }
}