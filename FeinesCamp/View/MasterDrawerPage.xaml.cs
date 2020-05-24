using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FeinesCamp.View
{
    public partial class MasterDrawerPage : ContentPage
    {
        //Menu Elements:
        public enum PageType
        {
            PerFer,
            Fetes,
            Clients,
            Preferences
        }

        public event EventHandler<PageType> PageSelected;

        public MasterDrawerPage()
        {
            InitializeComponent();

            btnPerFer.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.PerFer);
            btnFetes.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Fetes);
            btnClients.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Clients);
            btnPreferences.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Preferences);

        }
    }
}
