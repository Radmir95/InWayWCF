using System.Runtime.Serialization;

namespace InWay
{
    [DataContract]
    public class BusDriver
    {
        [DataMember(Order = 1)]
        public int BusDriverId { get; set; }

        [DataMember(Order = 2)]
        public string Login { get; set; }

    }
}