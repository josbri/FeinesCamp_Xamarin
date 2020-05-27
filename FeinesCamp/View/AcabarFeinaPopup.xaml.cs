using System;
using System.Collections.Generic;
using FeinesCamp.Model;
using FeinesCamp.ViewModel;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace FeinesCamp.View
{
    public partial class AcabarFeinaPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public AcabarFeinaPopup()
        {
            InitializeComponent();

        }
        public AcabarFeinaPopup(Tarea tarea) : this()
        {

            ((AcabarFeinaPopupViewModel)BindingContext).Tarea = tarea;

        }

        void Cancelar_Clicked(System.Object sender, System.EventArgs e)
        {
             PopupNavigation.RemovePageAsync(this);
        }
    }
}
