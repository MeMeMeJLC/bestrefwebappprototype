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
    public class BaseRepository : IRepository
    {
        private const string url = "http://refprototypeapiv5.azurewebsites.net/Api/teams/";
        private Team db = new Team();

        public async Task<Object> Add(Object item)
        {
            var table_name = item.GetType();
            var url = "http://refprototypeapiv5.azurewebsites.net/Api/" + table_name + "s";
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(url, item);


            return item;
        }

        public Object Get(int id, string table_name)
        {

            var url = "http://refprototypeapiv5.azurewebsites.net/Api/" + table_name + "s" + id;

            var client = new WebClient();
            var content = client.DownloadString(url);
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<Team>(content);
            return jsonContent;
        }

        public IEnumerable<Object> GetAll(string table_name)
        {

            string url = "http://refprototypeapiv5.azurewebsites.net/Api/" + table_name + "s";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(url).Result;

            var dataObjects = response.Content.ReadAsAsync<IEnumerable<Team>>().Result;
            return dataObjects;

        }

        public void Remove(int id, string table_name)
        {

            var url = "http://refprototypeapiv5.azurewebsites.net/Api/" + table_name +"/" + id;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync(url).Result;

        }

        public async Task<bool> Update(Object item, int id)
        {
            Team team = new Team();

            var table_name = item.GetType();
            var url = "http://refprototypeapiv5.azurewebsites.net/Api/" + table_name + "/" + id;
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync(url, item);

            return true;
        }
    }
}