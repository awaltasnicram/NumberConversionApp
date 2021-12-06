using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    
    // kontrakt
    [ServiceContract]
    public interface IConversionService
    {

        [OperationContract]
        Response Convert(string value);


     
    }




}