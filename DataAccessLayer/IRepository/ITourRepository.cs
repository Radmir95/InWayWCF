using InWay.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ITourRepository
    {

        void AddTour(Tour tour);
        void DeleteTour(Tour tour);
        void UpdateTour(Tour tour);
        int GetTourId(Tour tour);
        List<Tour> GetWaybillsOfDriver(int driverId);

    }
}
