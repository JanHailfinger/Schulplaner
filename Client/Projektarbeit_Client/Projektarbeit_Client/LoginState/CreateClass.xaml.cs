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
    public partial class CreateClass : ContentPage
    {
        public CreateClass()
        {
            InitializeComponent();

            btn_create.Clicked += Btn_create_Clicked;
            btn_back.Clicked += Btn_back_Clicked;

        }

        private void Btn_back_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JoinorCreateClassPage());
            Navigation.RemovePage(this);
        }

        private void Btn_create_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("Registrierungsfehler", "Bitte stellen sie sicher das sie mit dem Internet verbunden sind", "Ok");
                return;
            }

            if (txt_name.Text == null || txt_description.Text == null || txt_school.Text == null)
            {
                DisplayAlert("Fehler", "Bitte Füllen sie zuerst alle Felder aus", "OK");
                return;
            }

            int StatusCode = TCPCommandManager.CreateClass(txt_name.Text, txt_description.Text, txt_school.Text, switch_stundenplanrechte.IsToggled, switch_createAufgabe.IsToggled, switch_deleteAufgabe.IsToggled, switch_createTermin.IsToggled, switch_deleteTermin.IsToggled);

            switch (StatusCode)
            {
                case 201:
                    Navigation.PushAsync(new ControllPanel());
                    Navigation.RemovePage(this);
                    break;
                case 202:
                    DisplayAlert("Fehler", "Deine Erstellungsanfrage konnte nicht bearbeitet werden", "OK");
                    break;
                case 203:
                    DisplayAlert("Fehler", "Du hast keine Rechte eine Klasse zu Erstellen", "OK");
                    break;
                case 300:
                    DisplayAlert("Fehler", "Server Fehler bitte versuche es Später erneut", "OK");
                    break;
            }

            return;
        }
    }
}