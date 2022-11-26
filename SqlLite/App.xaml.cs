using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqlLite
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
            //sincronizacion sqlite - serverWeb rest

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
