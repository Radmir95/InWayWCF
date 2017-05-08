using System.ServiceModel;
using System.ServiceModel.Web;

namespace InWay
{

    [ServiceContract]
    public interface IBusDriverLogin
    {
        [OperationContract]
        [WebGet(UriTemplate = "/TryLogin/?login={login}&?password={password}", ResponseFormat = WebMessageFormat.Json)]
        BusDriver TryLogin(string login, string password);
    }
}
