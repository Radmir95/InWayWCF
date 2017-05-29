using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using InWay.Core.Entity;

namespace InWay
{
    public class TourService : ITourService
    {

        [WebGet(UriTemplate = "/GetTours/?driverId={driverId}&?password={password}", ResponseFormat = WebMessageFormat.Json)]
        public List<Tour> GetTours(int driverId, string password)
        {
            IBusDriverRepository busDriverRepository = new BusDriverRepository();
            BusDriver driver = busDriverRepository.GetBusDriver(driverId, password);

            if (driver.BusDriverId == -1) return null;




            return new List<Tour>(){new Tour(){Distance = 300}, new Tour(){Distance = 499}};

        }
    }
}
