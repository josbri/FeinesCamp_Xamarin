using System;
using System.Collections.Generic;
using FeinesCamp.Model;
using FeinesCamp.Utility;
using FeinesCamp.ViewModel;
using Xamarin.Forms;

namespace FeinesCamp.View
{
    public partial class TareaDetailsPage : ContentPage
    {
        public TareaDetailsPage()
        {
            InitializeComponent();
            //BindingContext = ViewModelLocator.TareaDetailsViewModel;
            BindingContext = new TareaDetailsViewModel();
        }

        async void Cancelar_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Guardar_Clicked(System.Object sender, System.EventArgs e)
        {

            if (((TareaDetailsViewModel)BindingContext).SaveTareaCommand.CanExecute(null))
            {
                ((TareaDetailsViewModel)BindingContext).SaveTareaCommand.Execute(null);
            }
            await Navigation.PopAsync();
        }
    }
}
