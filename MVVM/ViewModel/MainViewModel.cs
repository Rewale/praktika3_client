using ServiceClient_app.Core;
using ServiceClient_app.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Windows;
using System.Collections.ObjectModel;
using ServiceClient_app.MVVM.View;

namespace ServiceClient_app.MVVM.ViewModel
{

    public class MainViewModel: ObservableObject
    {
        public class OptionComboBox
        {
            public RelayCommand RelayCommand { get; set; }
            public string Title { get; set; }
        }
        public class DiscountFilterOptionComboBox : OptionComboBox
        {
            public DiscountFilterOptionComboBox(int min, int max, ObservableCollection<Service> services)
            {
                this.Title = $"от {min}% до {max}";
                RelayCommand = new RelayCommand(id => FilterByDiscount(min, max, services));
            }

            public void FilterByDiscount(int min, int max, ObservableCollection<Service> services)
            {
                services = new ObservableCollection<Service>(services.Where(p => min <= p.Discount && p.Discount < max).ToList());
            }
        }
        void UpdateCounts()
        {
            OnPropertyChanged(nameof(TotalCount));
            OnPropertyChanged(nameof(CurrentCount));
        }
        // Data

        public int TotalCount
        {
            get
            {
                return hash_services.Count;
            }
        }
        public int CurrentCount
        {
            get
            {
                return services.Count;
            }
        }
        public Service selectedService { get;set; }

        private ObservableCollection<Service> _service;
        public ObservableCollection<Service> services 
        {
            get
            {
                return _service;
            }
            set
            {
                _service = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<OptionComboBox> _optionsSort = new ObservableCollection<OptionComboBox>();
        public ObservableCollection<OptionComboBox> optionsSort
        {
            get
            {
                return _optionsSort;
            }
            set
            {
                _optionsSort = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<OptionComboBox> _discountOptions;
        public ObservableCollection<OptionComboBox> DiscountOptions
        {
            get
            {
                return _discountOptions;
            }
            set
            {
                _discountOptions = value;
                OnPropertyChanged();
            }
        }

        // Commands
        private RelayCommand _deleteCommand;

        public RelayCommand DeleteCommand
        {
            get {
                return _deleteCommand ??
                    (_deleteCommand = new RelayCommand(id =>
                    {
                        int id_int = (int)id;
                        Service deleteService = services.FirstOrDefault(p => p.id == id_int);
                        if(deleteService!= null)
                        {
                            Message message = deleteService.Delete();
                            if(!message.succses)
                            {
                                MessageBox.Show(message.message);
                            }
                            else
                            {
                                services.Remove(deleteService);
                                MessageBox.Show(message.message);

                                NotifyServices();
                            }
                        }
                    }));
            }
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                {
                    new EditWindow().ShowDialog();
                    UpdateServices();
                    NotifyServices();
                }));
            }

        }
        public void NotifyServices()
        {
            OnPropertyChanged("services");
        }

        private List<Service> hash_services { get; set; }

        private void UpdateServices()
        {
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetStringAsync(Settings.ServiceListUrl).Result;
            List<Service> services_list = JsonConvert.DeserializeObject<List<Service>>(task);
            hash_services = services_list;
            services_list.ForEach(p => p.DeleteCommand = DeleteCommand);
            services = new ObservableCollection<Service>(services_list);
        }

        public MainViewModel()
        {
            UpdateServices();
            var order = new OptionComboBox() { RelayCommand = new RelayCommand(p => SortByPrice(SortBy.SortPrice)), Title = "По возрастанию" };
            optionsSort.Add(order);
            var orderDesc = new OptionComboBox() { RelayCommand = new RelayCommand(p => SortByPrice(SortBy.SortDescPrice)), Title = "По убыванию" };
            optionsSort.Add(orderDesc);
            SetOptions();

        }
        private void SetOptions()
        {
            DiscountOptions = new ObservableCollection<OptionComboBox>();
            DiscountOptions.Add(new OptionComboBox() { RelayCommand = new RelayCommand(p => Reset() ), Title="Все"});
            DiscountOptions.Add(new OptionComboBox() { RelayCommand = new RelayCommand(p => FilterByDiscount(0, 5)), Title="от 0% до 5%"});
            DiscountOptions.Add(new OptionComboBox() { RelayCommand = new RelayCommand(p => FilterByDiscount(5, 15)), Title="от 5% до 15%"});
            DiscountOptions.Add(new OptionComboBox() { RelayCommand = new RelayCommand(p => FilterByDiscount(15, 30)), Title="от 15% до 30%"});
            DiscountOptions.Add(new OptionComboBox() { RelayCommand = new RelayCommand(p => FilterByDiscount(30, 70)), Title="от 30% до 70%"});
            DiscountOptions.Add(new OptionComboBox() { RelayCommand = new RelayCommand(p => FilterByDiscount(70, 100)), Title="от 70% до 100%"});

        }
        void Reset()
        {
            services = new ObservableCollection<Service>(hash_services);
            UpdateCounts();
        }
        public void FilterByDiscount(int min, int max)
        {
            Reset();
            services = new ObservableCollection<Service>(services.Where(p => min <= p.Discount && p.Discount < max).ToList());
            SortByPrice(lastSort);
            UpdateCounts();
        }
        enum SortBy
        {
            SortPrice,
            SortDescPrice
        }
        SortBy lastSort { get; set; }
        void SortByPrice(SortBy sort)
        {
            lastSort = sort;
            switch (sort)
            {
                case SortBy.SortPrice:
                    services = new ObservableCollection<Service>(services.OrderBy(s => s.CurrentPrice).ToList());
                    break;
                case SortBy.SortDescPrice:
                    services = new ObservableCollection<Service>(services.OrderByDescending(s => s.CurrentPrice).ToList());
                    break;                  
            }
        }
    }
}
