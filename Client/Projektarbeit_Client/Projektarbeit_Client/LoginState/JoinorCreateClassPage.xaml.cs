using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projektarbeit_Client
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JoinorCreateClassPage : ContentPage
	{
        public JoinorCreateClassPage ()
		{
			InitializeComponent ();

            btn_create.Clicked += Btn_create_Clicked;
            btn_join.Clicked += Btn_join_Clicked;

		}

        private void Btn_join_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JoinClass());
            Navigation.RemovePage(this);
        }

        private void Btn_create_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateClass());
            Navigation.RemovePage(this);
        }
    }
}