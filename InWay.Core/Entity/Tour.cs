using System;
using System.Runtime.Serialization;

namespace InWay.Core.Entity
{

    [DataContract]
    public class Tour
    {

        [DataMember(Order = 1)]
        public int TourId { get;  set; }
        [DataMember(Order = 2)]
        public DateTime? TimeOfDeparture { get;  set; }
        [DataMember(Order = 3)]
        public DateTime? TimeOfArrival { get;  set; }
        [DataMember(Order = 4)]
        public int Distance { get;  set; }
        [DataMember(Order = 5)]
        public string PointOfDeparture { get;  set; }
        [DataMember(Order = 6)]
        public string PointOfArrival { get;  set; }

    }
}
