using InWay;
using System;

namespace InWay
{

    public class TestService : ITestService
    {
        #region ITestService Members

        public Message ComposeMessage(string header, string body)
        {
            Message message = new Message() { Header = header, Body = body };

            return message;
        }

        #endregion
    }
}
