using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Projektarbeit_Client.TCP.Datatype;
using Projektarbeit_Client.TCP;

using Newtonsoft.Json;

namespace Projektarbeit_Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditStundenplan : ContentPage
    {
        public EditStundenplan()
        {
            InitializeComponent();

            btn_set.Clicked += Btn_set_Clicked;
            btn_back.Clicked += Btn_back_Clicked;

            if (ClassDataSafe.Stundenplan != "")
            {
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

        }

        private void Btn_back_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ControllPanel());
            Navigation.RemovePage(this);
        }

        private void Btn_set_Clicked(object sender, EventArgs e)
        {
            Stundenplan sp = new Stundenplan();

            sp.stunden[0, 0] = monday_1.Text;
            sp.stunden[0, 1] = monday_2.Text;
            sp.stunden[0, 2] = monday_3.Text;
            sp.stunden[0, 3] = monday_4.Text;
            sp.stunden[0, 4] = monday_5.Text;
            sp.stunden[0, 5] = monday_6.Text;
            sp.stunden[0, 6] = monday_7.Text;
            sp.stunden[0, 7] = monday_8.Text;

            sp.stunden[1, 0] = tuesday_1.Text;
            sp.stunden[1, 1] = tuesday_2.Text;
            sp.stunden[1, 2] = tuesday_3.Text;
            sp.stunden[1, 3] = tuesday_4.Text;
            sp.stunden[1, 4] = tuesday_5.Text;
            sp.stunden[1, 5] = tuesday_6.Text;
            sp.stunden[1, 6] = tuesday_7.Text;
            sp.stunden[1, 7] = tuesday_8.Text;

            sp.stunden[2, 0] = wednesday_1.Text;
            sp.stunden[2, 1] = wednesday_2.Text;
            sp.stunden[2, 2] = wednesday_3.Text;
            sp.stunden[2, 3] = wednesday_4.Text;
            sp.stunden[2, 4] = wednesday_5.Text;
            sp.stunden[2, 5] = wednesday_6.Text;
            sp.stunden[2, 6] = wednesday_7.Text;
            sp.stunden[2, 7] = wednesday_8.Text;

            sp.stunden[3, 0] = thursday_1.Text;
            sp.stunden[3, 1] = thursday_2.Text;
            sp.stunden[3, 2] = thursday_3.Text;
            sp.stunden[3, 3] = thursday_4.Text;
            sp.stunden[3, 4] = thursday_5.Text;
            sp.stunden[3, 5] = thursday_6.Text;
            sp.stunden[3, 6] = thursday_7.Text;
            sp.stunden[3, 7] = thursday_8.Text;

            sp.stunden[4, 0] = friday_1.Text;
            sp.stunden[4, 1] = friday_2.Text;
            sp.stunden[4, 2] = friday_3.Text;
            sp.stunden[4, 3] = friday_4.Text;
            sp.stunden[4, 4] = friday_5.Text;
            sp.stunden[4, 5] = friday_6.Text;
            sp.stunden[4, 6] = friday_7.Text;
            sp.stunden[4, 7] = friday_8.Text;

           
            switch (TCPCommandManager.SetStundenplan(JsonConvert.SerializeObject(sp)))
            {
                case 201:
                    DisplayAlert("Erfolgreich", "Stundenplan konnte gespeichert", "OK");
                    Navigation.PushAsync(new ControllPanel());
                    Navigation.RemovePage(this);
                    break;
                default:
                    DisplayAlert("Fehler", "Stundenplan konnte nicht gesetzt werden", "OK");
                    break;
            }

        }
    }
}
/*
0,0 0,1
1,0 1,1
2,0 2,1
3,0 3,1
*/