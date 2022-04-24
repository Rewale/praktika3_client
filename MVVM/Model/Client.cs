using Newtonsoft.Json;
using ServiceClient_app.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient_app.MVVM.Model
{
    public class Client
    {
        public string FIO { get; set; }
        public int id { get; set; }

        public static List<Client> GetClients()
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetStringAsync(Settings.ClientListUrl).Result;

            return JsonConvert.DeserializeObject<List<Client>>(res);
        }

    }
}
