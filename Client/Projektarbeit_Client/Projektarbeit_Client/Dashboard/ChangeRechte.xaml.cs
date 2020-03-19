using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Projektarbeit_Client.TCP;

namespace Projektarbeit_Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeRechte : ContentPage
    {
        public ChangeRechte()
        {
            InitializeComponent();

            btn_back.Clicked += Btn_back_Clicked;
            btn_set.Clicked += Btn_set_Clicked;
        }

        private void Btn_set_Clicked(object sender, EventArgs e)
        {
            
            switch (TCPCommandManager.SetRechte(switch_stundenplanrechte.IsToggled, switch_createAufgabe.IsToggled, switch_deleteAufgabe.IsToggled, switch_createTermin.IsToggled, switch_deleteTermin.IsToggled))
            {
                case 201:
                    DisplayAlert("Erfolgreich","Rechte wurden geändert","OK");
                    Navigation.PushAsync(new ControllPanel());
                    Navigation.RemovePage(this);
                    break;
                default:
                    DisplayAlert("Fehlgeschlagen", "Rechte konnten nicht geändert werden", "OK");
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