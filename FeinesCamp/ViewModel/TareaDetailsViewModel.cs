using System;
using FeinesCamp.Model;

namespace FeinesCamp.ViewModel
{
    public class TareaDetailsViewModel : BaseViewModel

    {
        public TareaDetailsViewModel()
        {
        }

        public TareaDetailsViewModel(Tarea tarea) : this()
        {

            Title = $"{tarea.Name} {tarea.Land.Name} {tarea.ClientName}";

        }

        Tarea tarea;
        public Tarea Tarea
        {
            get => tarea;
            set
            {
                if (tarea == value)
                    return;

                tarea = value;

                Title = $"{Tarea.Name} {tarea.Land.Name} {tarea.ClientName}";

                OnPropertyChange();
            }
        }
    }
}
