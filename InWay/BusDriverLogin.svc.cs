
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;

namespace InWay
{

    public class BusDriverLogin : IBusDriverLogin
    {
        public BusDriver TryLogin(string login, string password)
        {

            IBusDriverRepository driver = new BusDriverRepository();

            BusDriver busDriver = driver.GetBusDriver(login, password);

            //ITourRepository tourRepository = new TourRepository();
            // var busDriver = busDriverRepository.GetBusDriver(login, password);

            return busDriver;


        }
    }
}
