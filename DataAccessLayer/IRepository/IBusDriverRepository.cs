using InWay;

namespace DataAccessLayer.IRepository
{
    public interface IBusDriverRepository
    {

        BusDriver GetBusDriver(string login, string password);

    }
}
