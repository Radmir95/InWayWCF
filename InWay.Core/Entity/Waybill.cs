using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InWay.Core.Entity
{

    [DataContract]
    public class Waybill
    {
        [DataMember(Order = 1)]
        private List<Tour> Tours { get; set; }

    }
}
