using System;
using System.Collections.Generic;
using FeinesCamp.Model;
using Xamarin.Forms;

namespace FeinesCamp.View
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var tarea = e.SelectedItem as Tarea;

            if (tarea == null)
                return;

            await Navigation.PushAsync(new TareaDetailsPage(tarea));

            //Deselect item:
            ((ListView)sender).SelectedItem = null;
        }

        async void Nova_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TareaDetailsPage());
        }
    }
}
