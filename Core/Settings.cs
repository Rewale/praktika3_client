using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient_app.Core
{
    static public class Settings
    {
        public static string BaseUrl = "http://localhost/services_clients/";

        public static string ClientListUrl = BaseUrl + "api/Clients";
        public static string ServiceListUrl = BaseUrl + "api/Services";
        public static string ClientServiceListUrl = BaseUrl + "api/ClientServices";
    }
}
