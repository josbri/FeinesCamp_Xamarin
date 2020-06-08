using System;
using System.Collections.Generic;
using FeinesCamp.Model;
using FeinesCamp.Utility;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace FeinesCamp.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = ViewModelLocator.FeinaListViewModel;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var tarea = e.SelectedItem as Tarea;

            if (tarea == null)
                return;

            //await Navigation.PushAsync(new TareaDetailsPage(tarea));
            await PopupNavigation.Instance.PushAsync(new AcabarFeinaPopup(tarea));

            //Deselect item:
            ((ListView)sender).SelectedItem = null;
        }

        async void Nova_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TareaDetailsPage());
        }
    }
}
