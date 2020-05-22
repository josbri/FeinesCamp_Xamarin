using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using FeinesCamp.Data;
using FeinesCamp.Model;
using MvvmHelpers;
using Xamarin.Forms;

namespace FeinesCamp.ViewModel
{
    public partial class FeinaListViewModel : BaseViewModel
    {
        //From MvvmHelpers, ObservableRangeCollection
        public ObservableRangeCollection<Tarea> Feines { get; }
        public ObservableRangeCollection<Tarea> FeinesSearch { get; set; }
        public User User { get; set;  }
        public Command GetUserCommand { get; }
        public Command SearchTaskCommand { get; }

        public FeinaListViewModel()
        {
            //We use ObservableCollection so we are notified that there's a change.
            Feines = new ObservableRangeCollection<Tarea>();
            FeinesSearch = new ObservableRangeCollection<Tarea>();
            User = new User();
            Title = "Feines";

           
            GetUserCommand = new Command<string>(async (id) => await GetUserAsync(id));
            SearchTaskCommand = new Command<string>(async (searchText) => SearchTasks(searchText)); 
            //If we want it to call the api in the constructor:
            GetUserCommand.Execute("5e93600fd89dee0bdd199f47");
        }

        async Task GetUserAsync(string id)
        {
            //If it's already getting the data, don't get the data.
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                User getUser = await DataService.GetUserAsync("5e93600fd89dee0bdd199f47");
                //From mvvmhelpers:
                if (getUser != null)
                {
                    User = getUser;
                    Feines.ReplaceRange(getUser.Tasks);
                    FeinesSearch.ReplaceRange(getUser.Tasks);

                    Title = $"{Feines.Count} feines";

                    //Save to persistence
                    LocalDataService.SaveUserAsync(getUser);
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get user: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async void SearchTasks(string search)
        {
            if (search.Length > 1 || Feines == null || IsBusy)
                return;

            try
            {
                var searchList = Feines.Where((f) => f.Name.ToLower().Contains(search.ToLower()) ||
                f.ClientName.ToLower().Contains(search.ToLower()) || f.Land.Name.ToLower().Contains(search.ToLower()));
                FeinesSearch.ReplaceRange(searchList);

                Title = $"{FeinesSearch.Count} feines";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while searching {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }

        }



        
    }
}
