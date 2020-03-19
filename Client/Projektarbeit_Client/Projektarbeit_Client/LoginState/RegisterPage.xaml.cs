using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using Projektarbeit_Client.TCP;

namespace Projektarbeit_Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            picker_gender.Items.Add("Maennlich");
            picker_gender.Items.Add("Weiblich");
            picker_gender.Items.Add("Diverse");
            btn_register.Clicked += btn_register_clicked;

            var btn_backtologin_click = new TapGestureRecognizer();
            btn_backtologin_click.Tapped += btn_backtologin_clicked;
            btn_backtologin.GestureRecognizers.Add(btn_backtologin_click);
        }

        private void btn_backtologin_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);

        }

        private void btn_register_clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("Registrierungsfehler", "Bitte stellen sie sicher das sie mit dem Internet verbunden sind", "Ok");
                return;
            }

            if (switch_agb.IsToggled == false || switch_datenschutz.IsToggled == false)
            {
                DisplayAlert("Registrierungsfehler", "Bitte Akzeptieren sie die AGB's und die Datenschutzerklärung", "Ok");
                return;
            }

            if (txt_firstname.Text != null || txt_lastname.Text != null || txt_email.Text != null || txt_password.Text != null || txt_password2.Text != null || picker_gender.SelectedItem != null)
            {

                if (txt_password.Text == txt_password2.Text)
                {

                    if (Regex.Match(txt_email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                    {
                        int code = TCPCommandManager.Register(txt_firstname.Text, txt_lastname.Text, txt_email.Text, txt_password.Text, picker_gender.SelectedItem.ToString());

                        switch (code)
                        {
                            case 201:
                                Navigation.PushAsync(new LoginPage());
                                Navigation.RemovePage(this);
                                DisplayAlert("Erfolgreich", "Du kannst dich jetzt Anmelden", "Ok");
                                return;
                            case 301:
                                DisplayAlert("Registrierungsfehler", "E-Mail wurde Schon verwendet", "Ok");
                                return;
                            default:
                                DisplayAlert("Registrierungsfehler", "Fehler beim Regestrieren Fehler Code " + code, "Ok");
                                return;
                        }

                    }
                    else
                    {
                        DisplayAlert("Registrierungsfehler", "Geben sie bitte eine Gültige E-Mail Adresse ein", "Ok");
                        return;
                    }
                }
                else
                {
                    DisplayAlert("Registrierungsfehler", "Die beiden Passwörter stimmen nicht überein", "Ok");
                    return;
                }
            }
            else
            {
                DisplayAlert("Registrierungsfehler", "Bitte füllen sie alle Felder aus", "Ok");
                return;
            }
        }
    }

}

