using System;
using System.Collections.Generic;
using FeinesCamp.Utility;
using Xamarin.Forms;

namespace FeinesCamp.View
{
    public partial class ClientDetailsPage : ContentPage
    {
        public ClientDetailsPage()
        {
            InitializeComponent();

            BindingContext = ViewModelLocator.ClientDetailsViewModel;
        }
    }
}
