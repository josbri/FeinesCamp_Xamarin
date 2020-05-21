using System;
using System.Collections.Generic;
using FeinesCamp.Model;
using FeinesCamp.ViewModel;
using Xamarin.Forms;

namespace FeinesCamp.View
{
    public partial class TareaDetailsPage : ContentPage
    {
        public TareaDetailsPage()
        {
            InitializeComponent();
        }

        public TareaDetailsPage(Tarea tarea) : this()
        {
            InitializeComponent();

            ((TareaDetailsViewModel)BindingContext).Tarea = tarea;

        }
    }
}
