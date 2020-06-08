using System;
using System.Collections.Generic;
using FeinesCamp.Utility;
using Xamarin.Forms;

namespace FeinesCamp.View
{
    public partial class ClientsListView : ContentPage
    {
        public ClientsListView()
        {
            InitializeComponent();

            BindingContext = ViewModelLocator.ClientsListViewModel;
        }
    }
}
