using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using InWay;
using InWay.Core.Entity;

namespace DataAccessLayer
{
    class Start
    {

        public static void Main(string[] args)
        {

            BusDriverRepository busDriverRepository = new BusDriverRepository();
            BusDriver busDriver = busDriverRepository.GetBusDriver("xml000", "pswd");
            

        }




    }
}
