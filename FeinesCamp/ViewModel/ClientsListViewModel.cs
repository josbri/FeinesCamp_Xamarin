using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FeinesCamp.Model;
using MvvmHelpers;
using Xamarin.Forms;

namespace FeinesCamp.ViewModel
{
    public class ClientsListViewModel:BaseViewModel
    {

        public ObservableRangeCollection<ClientGetDTO> Clients { get; }
        public ObservableRangeCollection<ClientGetDTO> ClientsSearch { get; }

        public Client Client { get; set; }

        public Command GetClientsCommand { get; }
        public Command SearchClientsCommand { get; }


        public ClientsListViewModel()
        {
            Title = "Clients";
            Clients = new ObservableRangeCollection<ClientGetDTO>();
            ClientsSearch = new ObservableRangeCollection<ClientGetDTO>();
            Client = new Client();

            SearchClientsCommand = new Command<string>(async (searchText) => SearchClients(searchText));
            GetClientsCommand = new Command(async () => await GetClientsAsync());
            GetClientsCommand.Execute(null);
        }


       async Task GetClientsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                var clients = LocalDataService.GetClients();

                if (clients != null)
                {
                    Clients.ReplaceRange(clients);
                    ClientsSearch.ReplaceRange(clients);
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get clients: {ex.Message}");

                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");

            }
            finally
            {
                IsBusy = false;
            }


        }

        async void SearchClients(string search)
        {
            if (Clients == null || IsBusy)
                return;

            try
            {
                var searchList = Clients.Where((f) => f.Name.ToLower().Contains(search.ToLower()));
                ClientsSearch.ReplaceRange(searchList);

                Title = $"{ClientsSearch.Count} clients";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while searching {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }

        }

    }
}
