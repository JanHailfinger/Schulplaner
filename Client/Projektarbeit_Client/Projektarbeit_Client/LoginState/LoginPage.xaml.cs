using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Projektarbeit_Client.TCP;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Projektarbeit_Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private double width = 0;
        private double height = 0;

        public LoginPage()
        {
            InitializeComponent();

            btn_login.Clicked += btn_login_clicked;

            var btn_createaccount_click = new TapGestureRecognizer();
            btn_createaccount_click.Tapped += btn_createaccount_clicked;
            btn_createaccount.GestureRecognizers.Add(btn_createaccount_click);

            var btn_forgotpassword_click = new TapGestureRecognizer();
            btn_forgotpassword_click.Tapped += btn_forgotpassword_clicked;
            btn_forgotpassword.GestureRecognizers.Add(btn_forgotpassword_click);
        }

        private void btn_forgotpassword_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
            Navigation.RemovePage(this);
        }

        private void btn_createaccount_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
            Navigation.RemovePage(this);
        }

        private void btn_login_clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                 DisplayAlert("Login Fehlgeschlagen", "Bitte stellen sie sicher das sie mit dem Internet verbunden sind", "Ok");
                return;
            }

            if (txt_email.Text == null || txt_password.Text == null)
            {
                DisplayAlert("Login Fehlgeschlagen", "Bitte füllen sie bitte alle Felder aus", "Ok");
                return;
            }

            if (!Regex.Match(txt_email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                DisplayAlert("Login Fehlgeschlagen", "Bitte geb eine Richtige Email Andresse an", "Ok");
                return;
            }

            if (TCPCommandManager.Login(txt_email.Text, txt_password.Text) == 201)
            {

                ControllPanelData.DownloadUserData();
                if (UserDataSafe.HasActivated)
                {
                    if (UserDataSafe.HasSelected)
                    {
                        Navigation.PushAsync(new ControllPanel());
                        Navigation.RemovePage(this);
                        return;
                    }
                    else
                    {
                        Navigation.PushAsync(new JoinorCreateClassPage());
                        Navigation.RemovePage(this);
                        return;
                    }
                }
                else
                {
                    Navigation.PushAsync(new ActivateAccount());
                    Navigation.RemovePage(this);
                    return;
                }

            }
            else
            {
                DisplayAlert("Anmeldeversuch Fehlgeschlagen", "Ihre E-Mail oder ihr Passwort ist falsch", "Ok");
                return;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
            }

            if (this.width > this.height)
            {
                label_anmeldung.Text = "Anmeldung - Schulplaner";
                img_logo.IsVisible = false;
            }
            else
            {
                label_anmeldung.Text = "Anmeldung";
                img_logo.IsVisible = true;
            }
        }
    }
}