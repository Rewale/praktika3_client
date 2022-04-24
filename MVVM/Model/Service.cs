using Newtonsoft.Json;
using ServiceClient_app.Core;
using ServiceClient_app.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceClient_app.MVVM.Model
{
    public class Service: ObservableObject
    {
        public int id { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public float Discount { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public Message Delete()
        {
            HttpClient client = new HttpClient();
            var result = client.DeleteAsync($"{Settings.ServiceListUrl}/{id}").Result;
            Message message = JsonConvert.DeserializeObject<Message>(result.Content.ReadAsStringAsync().Result);
            return message;
        }

        public string LastPrice
        {
            get
            {
                if(Discount > 0)
                {
                    return Cost.ToString();
                }

                return "";
            }
        }
        public string Validate()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if(DurationMin / 60 > 4)
            {
                stringBuilder.AppendLine("Длительность услуги не может быть больше 4 часов!");
            }

            if(Cost < 0 || DurationMin < 0 || Discount < 0)
            {
                stringBuilder.AppendLine("Значения не могут быть отрицательными");
            }

            return stringBuilder.ToString();
        }

        public bool Add()
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
            var result = client.PostAsync(Settings.ServiceListUrl, content).Result;

            return result.IsSuccessStatusCode;
        }

        public bool Save()
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
            var result = client.PutAsync(Settings.ServiceListUrl, content).Result;

            return result.IsSuccessStatusCode;
        }

        public float CurrentPrice
        {
            get
            {
                if(Discount > 0)
                {
                    return (Cost * (1 - Discount / 100));
                }

                return Cost;
            }

        }

        public int DurationMin
        {
            get
            {
                return Duration / 60;
            }
            set
            {
                Duration = value * 60;
            }

        }
        private RelayCommand _editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new RelayCommand(p =>
                {
                    var window = new EditWindow(this);
                    window.ShowDialog();
                    OnPropertyChanged(string.Empty);
                }));
            }
        }

    }
}
