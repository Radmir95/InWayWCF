using System.Runtime.Serialization;

namespace InWay
{
    [DataContract]
    public class Message
    {

        [DataMember(Order = 1)]
        public string Header { get; set; }

        [DataMember(Order = 2)]
        public string Body { get; set; }

    }
}