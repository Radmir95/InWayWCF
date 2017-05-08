using DataAccessLayer.Repository;

namespace InWay
{

    public class BusDriverLogin : IBusDriverLogin
    {
        public Message TryLogin(string login, string password)
        {

            var busDriverRepository = new BusDriverRepository();

            var busDriver = busDriverRepository.GetBusDriver(login, password);

            return new Message(){Header = "fesfe", Body = "fesfes"};


        }
    }
}
