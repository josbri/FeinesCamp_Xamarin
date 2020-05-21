using System;
using System.Collections.Generic;
using FeinesCamp.Model;
using Xamarin.Forms;

namespace FeinesCamp.View
{
    public partial class MainPage : ContentPage
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

    }
}
