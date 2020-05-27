using System;
using FeinesCamp.Data;
using FeinesCamp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeinesCamp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());

            MainPage = new FeinesCampMasterDetailPage();
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
