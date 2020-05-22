using System;
using FeinesCamp.Data;
using FeinesCamp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeinesCamp
{
    public partial class App : Application
    {
        /*static FCLocalDatabase localDatabase;

        public static FCLocalDatabase LocalDatabase
        {
            get
            {
                if (localDatabase == null)
                {
                    localDatabase = new FCLocalDatabase();
                }
                return localDatabase;
            }
        }*/
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
