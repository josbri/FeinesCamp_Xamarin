using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FeinesCamp.Model;
using FeinesCamp.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalDataService))]
namespace FeinesCamp.Services
{
   
    public class LocalDataService : ILocalDataService
    {

        public List<ClientGetDTO> GetClients()
        {

            if (App.Current.Properties.ContainsKey("user"))
            {
                var user = App.Current.Properties["user"] as User;

                var clients = user.Clients;

                return clients;
            }

            return null;
        }

        public List<TipoTarea> GetTipoTareas()
        {

            if (App.Current.Properties.ContainsKey("user"))
            {
                var user = App.Current.Properties["user"] as User;

                var tipoTareas = user.TipoTareas;

                return tipoTareas;
            }

            return null;
        }
        public async void SaveUserAsync(User user)
        {
            //var userJson = JsonConvert.SerializeObject(user);

            if (App.Current.Properties.ContainsKey("user"))
            {
                App.Current.Properties["user"] = user;
            }

            else
            {
                App.Current.Properties.Add("user", user);
            }

           await App.Current.SavePropertiesAsync(); 
        }
    }
}
