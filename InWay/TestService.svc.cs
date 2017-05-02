using DataAccessLayer.IRepository;
using InWay;
using InWay.DataAccessLayer.Repository;
using System;

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
