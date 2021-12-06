using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    // Klasa dziedziczona
    public class ConversionService : IConversionService
    {

       
        public Response Convert(string value)
        {
            var result = Convertor.Convert(value);

            return new Response()
            {
                result = result,
                error = (result == null ? "Żle wprowadzony format" : null) // zwrocenie tekstu, gdy wartosc jest inna niz liczba
            };
        }
    }

}
