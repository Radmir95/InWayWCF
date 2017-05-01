using System.ServiceModel;
using System.ServiceModel.Web;

namespace InWay
{

    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetMessage/?header={header}&?body={body}", ResponseFormat = WebMessageFormat.Json)]
        Message ComposeMessage(string header, string body);
    }

}
