using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using InWay.Core.Entity;

namespace InWay
{

    [ServiceContract]
    public interface ITourService
    {
     
        [OperationContract]
        List<Tour> GetTours(int driverId, string password);
    }
}
