using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;


namespace WCF
{
    class Program
    {
        // lączenie serwera do klienta
        static void Main(string[] args)
        {
            Uri adres = new Uri("http://localhost:64276/ConversionService.svc");
            ServiceHost host = new ServiceHost(typeof(ConversionService), adres);
            host.AddServiceEndpoint(typeof(IConversionService), new BasicHttpBinding(), adres);
            host.Open();
          
        }
    }
}