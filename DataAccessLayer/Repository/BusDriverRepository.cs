using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InWay;
using InWay.DataAccessLayer;

namespace DataAccessLayer.Repository
{
    public class BusDriverRepository
    {

        private readonly ConnectionContext _context;

        public BusDriverRepository()
        {
            _context = new ConnectionContext();
        }

        public BusDriver GetBusDriver(string login, string password)
        {

            var context = _context.Create();
            var conn = (SqlConnection) context;

            var cmdGetBusDriver =
                new SqlCommand(
                    "SELECT busDriverId FROM Drv_busDriverCredential WHERE login = @login and password = @password",
                    conn);

            var param = new SqlParameter
            {
                ParameterName = "@login",
                Value = login,
                SqlDbType = SqlDbType.NVarChar
            };

            cmdGetBusDriver.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@password",
                Value = password,
                SqlDbType = SqlDbType.NVarChar
            };

            cmdGetBusDriver.Parameters.Add(param);

            var tourId = -1;

            try
            {
                using (var dr = cmdGetBusDriver.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tourId = (int)dr["busDriverId"];
                    }
                }
            }
            catch (SqlException)
            {

            }
            finally
            {
                conn.Close();
            }

            var busDriver = new BusDriver
            {
                BusDriverId = tourId,
                Login = login
            };

            return busDriver;

        }


    }
}
