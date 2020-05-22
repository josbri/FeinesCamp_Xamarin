using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FeinesCamp.Model;

namespace FeinesCamp.Services
{
    public interface ILocalDataService
    {
        void SaveUserAsync(User user);

        List<ClientGetDTO> GetClients();

        List<TipoTarea> GetTipoTareas();
    }
}
