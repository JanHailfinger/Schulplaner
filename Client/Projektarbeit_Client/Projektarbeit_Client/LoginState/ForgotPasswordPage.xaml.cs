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
    public partial class ForgotPasswordPage : ContentPage
    {

        private double width = 0;
        private double height = 0;
        public ForgotPasswordPage()
        {
            InitializeComponent();

            var btn_startpage_click = new TapGestureRecognizer();
            btn_startpage_click.Tapped += btn_homemenu_clicked;
            btn_startpage.GestureRecognizers.Add(btn_startpage_click);

            var btn_code_click = new TapGestureRecognizer();
            btn_code_click.Tapped += Btn_code_click_Tapped;
            btn_code.GestureRecognizers.Add(btn_code_click);

            btn_resetpw.Clicked += btn_resetpw_clicked; 
        }

        private void Btn_code_click_Tapped(object sender, EventArgs e)
        {

            Navigation.PushAsync(new ForgotPasswordPageCode());
            Navigation.RemovePage(this);

        }

        private void btn_resetpw_clicked(object sender, EventArgs e)
        {
            if (txt_email.Text == null)
            {
                DisplayAlert("Fehler", "Bitte Füllen sie alle Felder aus", "Ok");
                return;
            }

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("Fehler", "Bitte stellen sie sicher das sie mit dem Internet verbunden sind", "Ok");
                return;
            }
            int test = TCPCommandManager.SendNewPasswordCode(txt_email.Text);
            switch (test) {
                case 201:
                    DisplayAlert("Info", "Ihnen wurde eine Code per E-Mail gesendet", "Ok");
                    Navigation.PushAsync(new ForgotPasswordPageCode());
                    Navigation.RemovePage(this);
                    break;
                case 202:
                    DisplayAlert("Fehler", "E-Mail konnte nicht gesendet werden", "Ok");
                    break;
                case 300:
                    DisplayAlert("Fehler", "E-Mail konnte nicht gesendet werden", "Ok");
                    break;
                default:
                    DisplayAlert("Fehler", "E-Mail konnte nicht gesendet werden" , "Ok");
                    break;
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
                img_logo.IsVisible = false;
            }
            else
            {
                img_logo.IsVisible = true;
            }
        }

        private void btn_homemenu_clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);
        }
    }
}