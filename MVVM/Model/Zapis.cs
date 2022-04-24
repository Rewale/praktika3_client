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
    public class Zapis
    {
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }

        public string TimeLeft
        {
            get
            {
                var left = (Date - DateTime.Now);
                return $"{left.Hours}ч. {left.Minutes}м.";
            }
        }


        public bool Add()
        {
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Settings.ClientServiceListUrl, content).Result;

            return res.IsSuccessStatusCode;


        }

        public static List<Zapis> GetZapises()
        {
            HttpClient client = new HttpClient();
            var content = client.GetStringAsync(Settings.ClientServiceListUrl).Result;

            return JsonConvert.DeserializeObject<List<Zapis>>(content);
        }
        

    }
}
