using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using Projektarbeit_Client.TCP;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Projektarbeit_Client
{
    public partial class App : Application
    {
        private string email = null, password_hash = null;

        public App()
        {
          

            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());


            if (email != null || password_hash != null)
            {
                if (TCPCommandManager.Login(email, password_hash) == 201)
                {
                    ControllPanelData.DownloadUserData();
                    if (UserDataSafe.HasActivated)
                    {
                        if (UserDataSafe.HasSelected)
                        {
                            MainPage = new NavigationPage(new ControllPanel());
                            return;
                        }
                        else
                        {
                            MainPage = new NavigationPage(new JoinorCreateClassPage());
                            return;
                        }
                    }
                    else
                    {

                        MainPage = new NavigationPage(new ActivateAccount());

                        return;
                    }
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
                
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }

            NavigationPage.SetHasNavigationBar(this, false);

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private async void getUserData()
        {
            email = await SecureStorage.GetAsync("email");
            password_hash = await SecureStorage.GetAsync("password_hash");
        }

    }
}
