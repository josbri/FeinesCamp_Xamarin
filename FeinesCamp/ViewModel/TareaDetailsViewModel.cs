using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using FeinesCamp.Model;
using MvvmHelpers;
using Xamarin.Forms;

namespace FeinesCamp.ViewModel
{
    public class TareaDetailsViewModel : BaseViewModel
    {
        Tarea _tarea;
        string _title;
        private ObservableRangeCollection<ClientGetDTO> _clients;
        public ObservableRangeCollection<ClientGetDTO> Clients {
            get => _clients;
            set {
                if (_clients == value)
                    return;

                _clients = value;


                OnPropertyChange();
            }
        }
        private ObservableRangeCollection<TipoTarea> _tipoTareas;
        public ObservableRangeCollection<TipoTarea> TipoTareas
        {
            get => _tipoTareas;
            set
            {
                if (_tipoTareas == value)
                    return;

                _tipoTareas = value;


                OnPropertyChange();
            }
        }

        private ClientGetDTO _selectedClient;
        public ClientGetDTO SelectedClient
        {
            get => _selectedClient;
            set
            {
                if (_selectedClient == value)
                    return;

                _selectedClient = value;


                OnPropertyChange();
            }
        }

        public Command GetInitialDataCommand { get; }
        public Tarea Tarea
        {
            get => _tarea;
            set
            {
                if (_tarea == value)
                    return;

                _tarea = value;

                //Title = $"{Tarea.Name} {Tarea.Land.Name} {Tarea.ClientName}";

                OnPropertyChange();
            }
        }

        public TareaDetailsViewModel()
        {
            Tarea = new Tarea();

            Title = "Nova feina";

            GetInitialDataCommand = new Command(async () => await GetInitialData());

            GetInitialDataCommand.Execute("");

        }

        public TareaDetailsViewModel(Tarea tarea) : this()
        {
            Tarea = tarea;

            Title = $"{tarea.Name} {tarea.Land.Name} {tarea.ClientName}";

        }



        async Task GetInitialData()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                GetInitialClients();
                GetInitialTipoTareas();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"No se pudo cargar al tarea: {ex.Message}");
                await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        void GetInitialClients()
        {

            Clients = new ObservableRangeCollection<ClientGetDTO>();
            var clients = LocalDataService.GetClients();
            Clients.ReplaceRange(clients);
        }

        void GetInitialTipoTareas()
        {
            TipoTareas = new ObservableRangeCollection<TipoTarea>();
            var tipoTareas = LocalDataService.GetTipoTareas();
            TipoTareas.ReplaceRange(tipoTareas);
        }

    }
}
