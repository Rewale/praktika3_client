using ServiceClient_app.Core;
using ServiceClient_app.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ServiceClient_app.MVVM.ViewModel
{
    public class AdminViewModel: ObservableObject
    {
        private ObservableCollection<Zapis> _zapisList;
        public ObservableCollection<Zapis> ZapisList
        {
            get
            {
                return _zapisList;
            }
            set
            {
                _zapisList = value;
                OnPropertyChanged();
            }
        }
        DispatcherTimer timer = new DispatcherTimer();
        public AdminViewModel()
        {
            Update(null, null);

            timer.Tick += new EventHandler(Update);
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Start();

        }

        void Update(object e, EventArgs eventArgs)
        {
            ZapisList = new ObservableCollection<Zapis>(Zapis.GetZapises().OrderBy(p=>p.Date));
        }



    }
}
