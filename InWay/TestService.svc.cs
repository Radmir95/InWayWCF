using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;

namespace InWay
{

    public class TestService : ITestService
    {

        public Message ComposeMessage(string header, string body)
        {

            ITourRepository tourRepository = new TourRepository();

            tourRepository.GetTourById(1);

            Message message = new Message() { Header = header, Body = body };

            return message;
        }

    }
}
