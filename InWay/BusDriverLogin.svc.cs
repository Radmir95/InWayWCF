using DataAccessLayer.Repository;

namespace InWay
{

    public class BusDriverLogin : IBusDriverLogin
    {
        public BusDriver TryLogin(string login, string password)
        {

            var busDriverRepository = new BusDriverRepository();

            var busDriver = busDriverRepository.GetBusDriver(login, password);

            return busDriver;


        }
    }
}
