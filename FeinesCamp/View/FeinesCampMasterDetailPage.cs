using System;
using Xamarin.Forms;
using static FeinesCamp.View.MasterDrawerPage;

namespace FeinesCamp.View
{
    public class FeinesCampMasterDetailPage : MasterDetailPage
    {
        public FeinesCampMasterDetailPage()
        {
            var master = new MasterDrawerPage();

            //Subscription to the page-selection event:
            master.PageSelected += OnPageSelected;

            //Icon for Ios:
            if (Device.RuntimePlatform == Device.iOS)
            {
                master.IconImageSource = ImageSource.FromFile("nav-menu-icon.png");
            }


            this.Master = master;
            this.Detail = new NavigationPage(new MainPage());

            this.MasterBehavior = MasterBehavior.Popover;

            //Navigation Logic.
            void OnPageSelected(object sender, PageType pageType)
            {
                Page page;

                switch (pageType)
                {
                    case PageType.PerFer:
                        page = new MainPage();
                        break;
                    //case PageType.Fetes: page = new SpeakersPage(); break;
                    case PageType.Clients:
                        page = new ClientsListView();
                        break;
                    //case PageType.Preferences: page = new RoomsPage(); break;
                    default:
                        page = new MainPage();
                        break;
                }

                Detail = new NavigationPage(page);
    }
                //Hide the drawer after use:

            try
            {
                IsPresented = false;
            }
            catch
            {
                Console.WriteLine("Error de navegacion.");
            }
        }
    }
}
