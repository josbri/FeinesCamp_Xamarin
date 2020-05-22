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
        private bool _isFinished;
        public bool IsFinished
        {
            get => _isFinished;
            set
            {
                if (_isFinished == value)
                    return;
                _isFinished = value;
                OnPropertyChange();
            }
        }

        private float _time;
        public float Time
        {
            get => _time;
            set
            {
                if (_time == value)
                    return;
                _time = value;
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
        private LandGetDTO _selectedLand;
        public LandGetDTO SelectedLand
        {
            get => _selectedLand;
            set
            {
                if (_selectedLand == value)
                    return;
                _selectedLand = value;
                OnPropertyChange();
            }
        }
        private TipoTarea _selectedTipoTarea;
        public TipoTarea SelectedTipoTarea
        {
            get => _selectedTipoTarea;
            set
            {
                if (_selectedTipoTarea == value)
                    return;
                _selectedTipoTarea = value;
                OnPropertyChange();
            }
        }
        public Command GetInitialDataCommand { get; }
        public Command SaveTareaCommand { get; }

        public Tarea Tarea
        {
            get => _tarea;
            set
            {
                if (_tarea == value)
                    return;
                _tarea = value;
                OnPropertyChange();
            }
        }

        private string _materialText;
        public string MaterialText
        {
            get => _materialText;
            set
            {
                if (_materialText == value)
                    return;
                _materialText = value;
                OnPropertyChange();
            }
        }
        private string _commentText;
        public string CommentText
        {
            get => _commentText;
            set
            {
                if (_commentText == value)
                    return;
                _commentText = value;
                OnPropertyChange();
            }
        }
        public TareaPostDTO _tareaToPost;

        public TareaPostDTO TareaToPost
        {

            get => _tareaToPost;
            set
            {
                if (_tareaToPost == value)
                    return;
                _tareaToPost = value;
                OnPropertyChange();
            }
        }
        public TareaDetailsViewModel()
        {
            Tarea = new Tarea();

            Title = "Nova feina";

            IsFinished = false;

            Time = 0;

            GetInitialDataCommand = new Command(async () => await GetInitialData());
            SaveTareaCommand = new Command(async () => await SaveTareaAsync());

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


        async Task SaveTareaAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                if (isValid())
                {
                    await DataService.SaveTareaAsync(TareaToPost);
                    await App.Current.MainPage.DisplayAlert("Tarea guardada correctament!", "",  "OK");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"No se pudo guardar la tarea: {ex.Message}");
                await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
                //await App.Current.MainPage.Navigation.PopAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }


        bool isValid()
        {
            if (SelectedClient != null && SelectedLand != null && SelectedClient != null && SelectedTipoTarea != null)
            {
                TareaToPost = new TareaPostDTO
                {
                    UserID = SelectedClient.UserID,
                    ClientName = SelectedClient.Name,
                    LandID = SelectedLand.ID,
                    CommentPre = CommentText,
                    Finished = DateTime.Now,
                    Created = DateTime.Now,
                    CommentPost = "",
                    Completed = IsFinished,
                    Image = SelectedTipoTarea.Image,
                    Name = SelectedTipoTarea.Name,
                    Time = Time > 0 ? Time : 0
                };

                return true;
            }

            else return false;
        }


    }
    
}
