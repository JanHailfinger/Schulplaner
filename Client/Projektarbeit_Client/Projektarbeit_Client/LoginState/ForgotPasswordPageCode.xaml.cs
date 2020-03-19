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
	public partial class ForgotPasswordPageCode : ContentPage
	{
		public ForgotPasswordPageCode ()
		{
			InitializeComponent ();

            btn_reset.Clicked += Btn_reset_Clicked;
            btn_back.Clicked += Btn_back_Clicked;

		}

        private void Btn_back_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
            Navigation.RemovePage(this);
        }

        private void Btn_reset_Clicked(object sender, EventArgs e)
        {
            if(txt_email.Text == null || txt_Code.Text == null || txt_password.Text == null || txt_password2.Text == null)
            {
                DisplayAlert("Fehler", "Bitte Füllen sie alle Felder aus", "Ok");
                return;
            }

            if (txt_password.Text != txt_password2.Text)
            {
                DisplayAlert("Fehler", "Die Beiden Passwörter stimmen nicht überein", "Ok");
                return;
            }

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("Fehler", "Bitte stellen sie sicher das sie mit dem Internet verbunden sind", "Ok");
                return;
            }

            switch (TCPCommandManager.ResetPassword(txt_password.Text,int.Parse(txt_Code.Text),txt_email.Text))
            {
                case 201:
                    Navigation.PushAsync(new LoginPage());
                    Navigation.RemovePage(this);
                    break;
                case 202:
                    DisplayAlert("Fehler", "Der Code stimmt nicht", "Ok");
                    break;
                case 300:
                    DisplayAlert("Fehler", "Systemfehler bitte versuchen sie es Später erneut", "Ok");
                    break;
            }
        }
    }
}