using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using Projektarbeit_Client.TCP;

using Projektarbeit_Client.TCP.Datatype;

using Newtonsoft.Json;

namespace Projektarbeit_Client
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControllPanel : TabbedPage
    {

        private double width = 0;
        private double height = 0;
        private bool timer = true;
        public ControllPanel()
        {
            InitializeComponent();

            btn_newTask.Clicked += Btn_newTask_Clicked;

            

            uebersicht_btn_rechtebearbeiten.Clicked += Uebersicht_btn_rechtebearbeiten_Clicked;
            uebersicht_btn_klassendatenbearbeiten.Clicked += Uebersicht_btn_klassendatenbearbeiten_Clicked;

            stundenplan_btn_edit.Clicked += Stundenplan_btn_edit_Clicked;

            btn_newTermin.Clicked += Btn_newTermin_Clicked;

            profil_btn_einladen.Clicked += Profil_btn_einladen_Clicked;
            profil_btn_leaveClass.Clicked += Profil_btn_leaveClass_Clicked;
            profil_btn_logout.Clicked += Profil_btn_logout_Clicked;
            profil_btn_refresh.Clicked += Profil_btn_refresh_Clicked;
            
            RefreshData();
        }

        private void Profil_btn_refresh_Clicked(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void Profil_btn_logout_Clicked(object sender, EventArgs e)
        {
            timer = false;
            TCPCommandManager.clearLoginData();
            Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);

        }

        private void Profil_btn_leaveClass_Clicked(object sender, EventArgs e)
        {
            switch (TCPCommandManager.LeaveClass())
            {
                case 201:
                    Navigation.PushAsync(new JoinorCreateClassPage());
                    Navigation.RemovePage(this);
                    DisplayAlert("Erfolgreich", "Du hast die Klasse verlassen", "OK");
                    break;
                default:
                    DisplayAlert("Fehlgeschlagen", "Es ist ein Fehler beim Löschen Passiert", "OK");
                    break;
            }
        }

        private void Profil_btn_einladen_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InviteUserPage());
            Navigation.RemovePage(this);
        }

        private void Btn_newTermin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNewTerminPage());
            Navigation.RemovePage(this);
        }

        private void Stundenplan_btn_edit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditStundenplan());
            Navigation.RemovePage(this);
        }

        private void Uebersicht_btn_klassendatenbearbeiten_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetClassData());
            Navigation.RemovePage(this);
        }

        private void Uebersicht_btn_rechtebearbeiten_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangeRechte());
            Navigation.RemovePage(this);
        }

        private void Btn_newTask_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNewTaskPage());
            Navigation.RemovePage(this);
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
                img_logo_tasks.IsVisible = false;
                txt_title_taks.IsVisible = false;
                img_logo_termin.IsVisible = false;
                txt_title_termin.IsVisible = false;
            }
            else
            {
                img_logo_tasks.IsVisible = true;
                txt_title_taks.IsVisible = true;
                img_logo_termin.IsVisible = true;
                txt_title_termin.IsVisible = true;
            }
        }

        public void DeleteTask(Object Sender, EventArgs e)
        {

            if(ClassDataSafe.Creator.Equals(TCPCommandManager.EMAIL, StringComparison.InvariantCultureIgnoreCase) == false)
            {
                if(ClassDataSafe.deleteAufgabe == false)
                {
                    DisplayAlert("Fehlgeschlagen", "Du Hast nicht die Rechte Dafür", "OK");
                    return;
                }

            }

            ImageButton btn = (ImageButton)Sender;
            string str_id = btn.BindingContext as string;
            int id = int.Parse(str_id);
            
            switch (TCPCommandManager.DeleteTask(id))
            {
                case 201:
                    DisplayAlert("Erfolgreich", "Du hast Erfolgreich diesen eintrag gelöscht", "OK");
                    break;
                default:
                    DisplayAlert("Fehlgeschlagen", "Es ist ein Fehler beim Löschen Passiert", "OK");
                    break;
            }
            RefreshData();

        }

        public void DeleteTermin(Object Sender, EventArgs e)
        {

            if (ClassDataSafe.Creator.Equals(TCPCommandManager.EMAIL, StringComparison.InvariantCultureIgnoreCase) == false)
            {
                if (ClassDataSafe.deleteTermin == false)
                {
                    DisplayAlert("Fehlgeschlagen", "Du Hast nicht die Rechte Dafür", "OK");
                    return;
                }

            }

            ImageButton btn = (ImageButton)Sender;
            string str_id = btn.BindingContext as string;
            int id = int.Parse(str_id);

            switch (TCPCommandManager.DeleteTermin(id))
            {
                case 201:
                    DisplayAlert("Erfolgreich", "Du hast Erfolgreich diesen eintrag gelöscht", "OK");
                    break;
                default:
                    DisplayAlert("Fehlgeschlagen", "Es ist ein Fehler beim Löschen Passiert", "OK");
                    break;
            }
            RefreshData();

        }


        private void RefreshData()
        {

            ControllPanelData.DownloadUserData();
            ControllPanelData.DownloadClassData();

            uebersicht_txt_Klassenname.Text = ClassDataSafe.ClassName;
            uebersicht_txt_Beschreibung.Text = ClassDataSafe.Description;
            uebersicht_txt_Schule.Text = ClassDataSafe.School;

            profil_txt_email.Text = TCPCommandManager.getEMail();
            profil_txt_geschlecht.Text = UserDataSafe.Gender;
            profil_txt_vorname.Text = UserDataSafe.Firstname;
            profil_txt_nachname.Text = UserDataSafe.Lastname;

            if(ClassDataSafe.Stundenplan != "") {
                Stundenplan sp = JsonConvert.DeserializeObject<Stundenplan>(ClassDataSafe.Stundenplan);


                monday_1.Text = sp.stunden[0, 0];
                monday_2.Text = sp.stunden[0, 1];
                monday_3.Text = sp.stunden[0, 2];
                monday_4.Text = sp.stunden[0, 3];
                monday_5.Text = sp.stunden[0, 4];
                monday_6.Text = sp.stunden[0, 5];
                monday_7.Text = sp.stunden[0, 6];
                monday_8.Text = sp.stunden[0, 7];

                tuesday_1.Text = sp.stunden[1, 0];
                tuesday_2.Text = sp.stunden[1, 1];
                tuesday_3.Text = sp.stunden[1, 2];
                tuesday_4.Text = sp.stunden[1, 3];
                tuesday_5.Text = sp.stunden[1, 4];
                tuesday_6.Text = sp.stunden[1, 5];
                tuesday_7.Text = sp.stunden[1, 6];
                tuesday_8.Text = sp.stunden[1, 7];

                wednesday_1.Text = sp.stunden[2, 0];
                wednesday_2.Text = sp.stunden[2, 1];
                wednesday_3.Text = sp.stunden[2, 2];
                wednesday_4.Text = sp.stunden[2, 3];
                wednesday_5.Text = sp.stunden[2, 4];
                wednesday_6.Text = sp.stunden[2, 5];
                wednesday_7.Text = sp.stunden[2, 6];
                wednesday_8.Text = sp.stunden[2, 7];

                thursday_1.Text = sp.stunden[3, 0];
                thursday_2.Text = sp.stunden[3, 1];
                thursday_3.Text = sp.stunden[3, 2];
                thursday_4.Text = sp.stunden[3, 3];
                thursday_5.Text = sp.stunden[3, 4];
                thursday_6.Text = sp.stunden[3, 5];
                thursday_7.Text = sp.stunden[3, 6];
                thursday_8.Text = sp.stunden[3, 7];

                friday_1.Text = sp.stunden[4, 0];
                friday_2.Text = sp.stunden[4, 1];
                friday_3.Text = sp.stunden[4, 2];
                friday_4.Text = sp.stunden[4, 3];
                friday_5.Text = sp.stunden[4, 4];
                friday_6.Text = sp.stunden[4, 5];
                friday_7.Text = sp.stunden[4, 6];
                friday_8.Text = sp.stunden[4, 7];
            }

            aufgabenview.ItemsSource = null;

            aufgabenview.ItemsSource = ControllPanelData.Tasks;

            terminview.ItemsSource = null;

            terminview.ItemsSource = ControllPanelData.Termine;



            //

            if (ClassDataSafe.Creator.Equals(TCPCommandManager.EMAIL, StringComparison.InvariantCultureIgnoreCase) == false)
            {
                profil_btn_einladen.IsVisible = false;
                uebersicht_btn_klassendatenbearbeiten.IsVisible = false;
                uebersicht_btn_rechtebearbeiten.IsVisible = false;

                if (ClassDataSafe.changeStundenplan == false)
                {
                    stundenplan_btn_edit.IsVisible = false;
                }

                if (ClassDataSafe.createAufgabe == false)
                {
                    btn_newTask.IsVisible = false;
                }

                if (ClassDataSafe.createTermin == false)
                {
                    btn_newTermin.IsVisible = false;
                }


            }
            else
            {
                profil_btn_einladen.IsVisible = true;
                uebersicht_btn_klassendatenbearbeiten.IsVisible = true;
                uebersicht_btn_rechtebearbeiten.IsVisible = true;
                stundenplan_btn_edit.IsVisible = true;
                btn_newTask.IsVisible = true;
                btn_newTermin.IsVisible = true;
            }

        }

        ~ControllPanel()
        {
            timer = false;
        }
    }
}