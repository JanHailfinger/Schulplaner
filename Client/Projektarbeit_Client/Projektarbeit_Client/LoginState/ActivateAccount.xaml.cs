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
	public partial class ActivateAccount : ContentPage
	{
		public ActivateAccount ()
		{
			InitializeComponent ();

            btn_activateaccount.Clicked += btn_activateaccount_clicked;

            var btn_newemail_click = new TapGestureRecognizer();
            btn_newemail_click.Tapped += Btn_newemail_click_Tapped; ;
            btn_sendnewemail.GestureRecognizers.Add(btn_newemail_click);

            switch (TCPCommandManager.SendNewActivationCode())
            {
                case 201:
                    DisplayAlert("Info", "Ihnen wurde eine neuer Code per E-Mail gesendet", "Ok");
                    break;
                case 202:
                    DisplayAlert("Fehler", "E-Mail konnte nicht gesendet werden", "Ok");
                    break;
                case 300:
                    DisplayAlert("Fehler", "E-Mail konnte nicht gesendet werden", "Ok");
                    break;
            }
        }

        private void Btn_newemail_click_Tapped(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("Fehler", "Bitte stellen sie sicher das sie mit dem Internet verbunden sind", "Ok");
                return;
            }

            switch (TCPCommandManager.SendNewActivationCode())
            {
                case 201:
                    DisplayAlert("Info", "Ihnen wurde eine neuer Code per E-Mail gesendet", "Ok");
                    break;
                case 202:
                    DisplayAlert("Fehler", "E-Mail konnte nicht gesendet werden", "Ok");
                    break;
                case 300:
                    DisplayAlert("Fehler", "E-Mail konnte nicht gesendet werden", "Ok");
                    break;
            }
            return;
        }

        private void btn_activateaccount_clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("Fehler", "Bitte stellen sie sicher das sie mit dem Internet verbunden sind", "Ok");
                return;
            }

            if (txt_code.Text == null)
            {
                DisplayAlert("Fehler", "Bitte füllen sie alle Felder aus", "Ok");
                return;
            }

            switch (TCPCommandManager.ActivateAccount(int.Parse(txt_code.Text)))
            {
                case 201:
                    ControllPanelData.DownloadUserData();
                    Navigation.PushAsync(new JoinorCreateClassPage());
                    Navigation.RemovePage(this);
                    
                    return;
                case 202:
                    DisplayAlert("Fehler", "Dieser Code ist nicht Gültig", "Ok");
                    break;
                case 300:
                    DisplayAlert("Fehler", "Server Fehler bitte versuchen sie es Später erneut", "Ok");
                    break;
            }

        }
    }
}