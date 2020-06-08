using System;
using FeinesCamp.ViewModel;

namespace FeinesCamp.Utility
{
    public static class ViewModelLocator
    {
        //TODO: Use DI.
        public static ClientsListViewModel ClientsListViewModel { get; set; }
            = new ClientsListViewModel();

        public static ClientDetailsViewModel ClientDetailsViewModel { get; set; }
            = new ClientDetailsViewModel();

        public static AcabarFeinaPopupViewModel AcabarFeinaPopupViewModel { get; set; }
            = new AcabarFeinaPopupViewModel();

        public static FeinaListViewModel FeinaListViewModel { get; set; }
            = new FeinaListViewModel();

        //public static TareaDetailsViewModel TareaDetailsViewModel { get; set; }
          //  = new TareaDetailsViewModel();
    }
}
