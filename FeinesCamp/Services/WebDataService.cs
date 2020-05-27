using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FeinesCamp.Data;
using FeinesCamp.Model;
using FeinesCamp.Services;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

//Dependency: IOC Container built in xamarin.forms
[assembly:Dependency(typeof(WebDataService))]
namespace FeinesCamp.Services
{
    public class WebDataService : IDataService
    {
        HttpClient httpClient;

        string Address = "http://partescampapi-dev.eu-west-1.elasticbeanstalk.com/api";

        // Return httpclient, unless it's null, then create a new httpclient.
        HttpClient Client => httpClient ?? (httpClient = new HttpClient());


        private TareaPostDTO TareaToPostDTO (Tarea tarea)
        {
            TareaPostDTO tareaPostDTO = new TareaPostDTO
            {
                ClientName= tarea.ClientName,
                CommentPost = tarea.CommentPro,
                CommentPre = tarea.CommentPre,
                Completed = tarea.Completed,
                Created = tarea.Created,
                Finished = tarea.Finished,
                Image = tarea.Image,
                LandID = tarea.LandID,
                Name = tarea.Name,
                Time = tarea.Time,
                UserID = tarea.UserID

            };

            return tareaPostDTO;
        }
        public async Task<User> GetUserAsync(string jwtId)
        {
            var connectionString = $"{Address}/Users/jwt/{jwtId}";
            var json = await Client.GetStringAsync(connectionString);

            var user = User.FromJson(json);
            return user;
            
        }

        public async Task SaveTareaAsync (TareaPostDTO tarea)
        {
            var connectionString = $"{Address}/Tasks";

            var tareaJson = JsonConvert.SerializeObject(tarea);

            var data = new StringContent(tareaJson, Encoding.UTF8, "application/json");

            await Client.PostAsync(connectionString, data);

        }

        public async Task UpdateTareaAsync (Tarea tarea)
        {
            var connectionString = $"{Address}/Tasks";

            var tareaJson = JsonConvert.SerializeObject(tarea);

            var data = new StringContent(tareaJson, Encoding.UTF8, "application/json");

            await Client.PutAsync(connectionString, data);
        }

    }
}
