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
    public partial class JoinClass : ContentPage
    {
        public JoinClass()
        {
            InitializeComponent();

            btn_join.Clicked += Btn_join_Clicked;
            btn_back.Clicked += Btn_back_Clicked;
        }

        private void Btn_back_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JoinorCreateClassPage());
            Navigation.RemovePage(this);
        }

        private void Btn_join_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("Registrierungsfehler", "Bitte stellen sie sicher das sie mit dem Internet verbunden sind", "Ok");
                return;
            }

            if (txt_Code.Text == null)
            {
                DisplayAlert("Fehler", "Bitte Füllen sie zuerst alle Felder aus", "OK");
                return;
            }

            int StatusCode = TCPCommandManager.JoinClass(int.Parse(txt_Code.Text));

            switch (StatusCode)
            {
                case 201:
                    Navigation.PushAsync(new ControllPanel());
                    Navigation.RemovePage(this);
                    break;
                case 202:
                    DisplayAlert("Fehler", "Dein Code ist nicht gültig lasse dich erneut einladen", "OK");
                    break;
                case 203:
                    DisplayAlert("Fehler", "Du hast keine Rechte einer Klasse Beizutreten", "OK");
                    break;
                case 300:
                    DisplayAlert("Fehler", "Server Fehler bitte versuche es Später erneut", "OK");
                    break;
            }

            return;
        }
    }
}