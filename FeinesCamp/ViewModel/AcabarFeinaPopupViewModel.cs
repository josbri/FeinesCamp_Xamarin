using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FeinesCamp.Model;
using Xamarin.Forms;

namespace FeinesCamp.ViewModel
{
    public class AcabarFeinaPopupViewModel : BaseViewModel
    {
        private Tarea _tarea;
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
        private string _material;
        public string Material
        {
            get => _material;
            set
            {
                if (_material == value)
                    return;
                _material = value;
                OnPropertyChange();
            }
        }

        private string _comentari;
        public string Comentari
        {
            get => _comentari;
            set
            {
                if (_comentari == value)
                    return;
                _comentari = value;
                OnPropertyChange();
            }
        }
        private float _time;
        public float Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChange();
            }
        }
        public Command SaveTarea { get; set; }
       
        public AcabarFeinaPopupViewModel()
        {
            Tarea = new Tarea();
            Material = Tarea.Material ?? " ";
            Comentari = Tarea.CommentPro ?? " ";
            Time = Tarea.Time > 0 ? Tarea.Time : 0;
            SaveTarea = new Command(async () => await SaveTareaAsync());
        }
        public AcabarFeinaPopupViewModel(Tarea tarea): this()
        {
            Tarea = tarea;
           
        }


        async Task SaveTareaAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                {
                    if (Time > 0)
                    {

                        Tarea.Completed = true;
                        Tarea.CommentPro = Comentari;
                        Tarea.Time = Time;
                        Tarea.Material = Material;
                        await DataService.UpdateTareaAsync(Tarea);
                        await App.Current.MainPage.DisplayAlert("Tarea guardada correctament!", "", "OK");

                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"No se pudo guardar la tarea: {ex.Message}");
                await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
