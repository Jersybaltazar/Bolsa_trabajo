using app_CIP.page;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_CIP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new prueba());
            //MainPage = new prueba();
            MainPage = new FlyoutPage1
            {
                Flyout = new FlyoutPage1Flyout(),
                Detail = new NavigationPage(new pagina_inicio())
            };


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
