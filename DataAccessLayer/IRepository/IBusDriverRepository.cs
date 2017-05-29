using InWay;

namespace DataAccessLayer.IRepository
{
    public interface IBusDriverRepository
    {

        BusDriver GetBusDriver(int driverId, string password);
        BusDriver GetBusDriver(string login, string password);

    }
}
