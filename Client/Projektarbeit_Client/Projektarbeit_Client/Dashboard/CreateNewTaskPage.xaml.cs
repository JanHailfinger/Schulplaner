using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projektarbeit_Client.TCP;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Projektarbeit_Client
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateNewTaskPage : ContentPage
	{
		public CreateNewTaskPage ()
		{
			InitializeComponent ();
            btn_create.Clicked += Btn_create_Clicked;
		}

        private void Btn_create_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("Keine Verbindung Möglich", "Bitte stellen sie sicher das sie mit dem Internet verbunden sind", "OK");
                return;
            }
            if(txt_title.Text == null || txt_description.Text == null)
            {
                DisplayAlert("Fehler", "Bitte füllen sie alle Felder aus", "OK");
                return;
            }

            switch (TCPCommandManager.CreateTask(txt_title.Text, txt_description.Text, txt_date.Date.ToShortDateString())) {
                case 201:
                    Navigation.PushAsync(new ControllPanel());
                    Navigation.RemovePage(this);
                    DisplayAlert("Erfolgreich", "Die Aufgabe wurde erstellt", "OK");
                    break;
                default:
                    DisplayAlert("Fehler", "Die Aufgabe konnte nicht erstellt werden", "OK");
                    break;
            }
        }
    }
}