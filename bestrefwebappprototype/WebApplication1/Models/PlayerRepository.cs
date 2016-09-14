using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace WebApplication1.Models
{
    public class PlayerRepository : IRepository
    {
        private const string url = "http://refprototypeapiv5.azurewebsites.net/Api/";
        //private Player db = new Player();

        public async Task<Object> Add(Object item)
        {
            //var table_name = item.GetType();
            var url = "http://refprototypeapiv5.azurewebsites.net/Api/" + "players";
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(url, item);

            /*string url2 = "http://refprototypeapiv5.azurewebsites.net/Api/" + "players";
            HttpClient client2 = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response2 = client.GetAsync(url).Result;

            var dataObjects = response2.Content.ReadAsAsync<IEnumerable<Team>>().Result;*/

            return item;
        }

        public Object Get(int id, string table_name)
        {

            var url = "http://refprototypeapiv5.azurewebsites.net/Api/" + "players/" + id;

            var client = new WebClient();
            var content = client.DownloadString(url);
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<Player>(content);


            string url2 = "http://refprototypeapiv5.azurewebsites.net/Api/" + "teams/" + jsonContent.team_id;
            var client2 = new WebClient();
            var content2 = client2.DownloadString(url2);
            var serializer2 = new JavaScriptSerializer();
            var team = serializer2.Deserialize<Team>(content2);

            jsonContent.team_name = team.team_name;

            return jsonContent;
        }
        

        public IEnumerable<Object>GetAll(string table_name)
        {

            string url = "http://refprototypeapiv5.azurewebsites.net/Api/" + "players";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(url).Result;

            var dataObjects = response.Content.ReadAsAsync<IEnumerable<Player>>().Result;
            foreach(Player p in dataObjects)
            {
                string url2 = "http://refprototypeapiv5.azurewebsites.net/Api/" + "teams/" + p.team_id;
                var client2 = new WebClient();
                var content = client2.DownloadString(url2);
                var serializer = new JavaScriptSerializer();
                var team = serializer.Deserialize<Team>(content);

                p.team_name = team.team_name;
            }

            return dataObjects;

        }

        public void Remove(int id, string table_name)
        {

            var url = "http://refprototypeapiv5.azurewebsites.net/Api/" + "players/" + id;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync(url).Result;

        }

        public async Task<bool> Update(Object item, int id)
        {
            Object updated_item = new Object();

            var table_name = item.GetType();
            var url = "http://refprototypeapiv5.azurewebsites.net/Api/" + "players/" + id;
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync(url, item);

            return true;
        }
    }
}