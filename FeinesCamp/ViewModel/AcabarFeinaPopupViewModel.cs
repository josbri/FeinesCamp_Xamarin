using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FeinesCamp.Model;

namespace FeinesCamp.ViewModel
{
    public class AcabarFeinaPopupViewModel : BaseViewModel
    {
        public Tarea _tarea;
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

       
        public AcabarFeinaPopupViewModel()
        {
            Tarea = new Tarea();
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
                    await DataService.UpdateTareaAsync(Tarea);
                    await App.Current.MainPage.DisplayAlert("Tarea guardada correctament!", "", "OK");

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
