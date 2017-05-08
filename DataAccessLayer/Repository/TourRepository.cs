using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccessLayer.IRepository;
using InWay.Core.Entity;

namespace DataAccessLayer.Repository
{
    public class TourRepository : ITourRepository
    {

        private readonly ConnectionContext _context;

        public TourRepository()
        {
            _context = new ConnectionContext();
        }

        public void AddTour(Tour tour)
        {

            var context = _context.Create();
            var conn = (SqlConnection)context;

            var cmdAddTour = new SqlCommand("INSERT INTO Tour" +
            "(timeOfDeparture, timeOfArrival, distance, pointOfDeparture, pointOfArrival)"
            + " VALUES (@timeOfDeparture, @timeOfArrival, @distance, @pointOfDeparture, @pointOfArrival)", conn);

            var param = new SqlParameter()
            {
                ParameterName = "@timeOfDeparture",
                Value = tour.TimeOfDeparture,
                SqlDbType = SqlDbType.DateTime
            };

            cmdAddTour.Parameters.Add(param);

            param = new SqlParameter()
            {
                ParameterName = "@timeOfArrival",
                Value = tour.TimeOfArrival,
                SqlDbType = SqlDbType.DateTime
            };
            cmdAddTour.Parameters.Add(param);

            param = new SqlParameter()
            {
                ParameterName = "@distance",
                Value = tour.Distance,
                SqlDbType = SqlDbType.Int
            };

            cmdAddTour.Parameters.Add(param);

            param = new SqlParameter()
            {
                ParameterName = "@pointOfDeparture",
                Value = tour.PointOfDeparture,
                SqlDbType = SqlDbType.Text
            };

            cmdAddTour.Parameters.Add(param);

            param = new SqlParameter()
            {
                ParameterName = "@pointOfArrival",
                Value = tour.PointOfArrival,
                SqlDbType = SqlDbType.Text
            };
            cmdAddTour.Parameters.Add(param);

            try
            {
                cmdAddTour.ExecuteNonQuery();
            }
            catch (SqlException)
            {

            }
            finally
            {
                conn.Close();
            }

        }

        public void DeleteTour(Tour tour)
        {




        }

        public void UpdateTour(Tour tour)
        {




        }

        public int GetTourId(Tour tour)
        {

            var context = _context.Create();
            var conn = (SqlConnection)context;

            var cmdGetTourId =
                new SqlCommand(
                    "SELECT tourId FROM Tour WHERE distance = @distance",
                    conn);

            var param = new SqlParameter();

            param.ParameterName = "@distance";
            param.Value = tour.Distance;
            param.SqlDbType = SqlDbType.Int;
            cmdGetTourId.Parameters.Add(param);

            var tourId = 0;

            try
            {
                using (var dr = cmdGetTourId.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tourId = (int)dr["tourId"];
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

            return tourId;

        }

        public Tour GetTourById(int tourId)
        {

            /* var context = _context.Create();
             var conn = (SqlConnection)context;

             var cmdGetTour =
                 new SqlCommand(
                     "SELECT tourId, timeOfDeparture, timeOfArrival, distance, pointOfDeparture, pointOfArrival FROM Tour WHERE tourId = @tourId",
                     conn);

             var param = new SqlParameter();

             param.ParameterName = "@tourId";
             param.Value = tourId;
             param.SqlDbType = SqlDbType.Int;
             cmdGetTour.Parameters.Add(param);

             Tour tour = null;

             try
             {
                 using (var dr = cmdGetTour.ExecuteReader())
                 {
                     while (dr.Read())
                     {
                         tour = new Tour((DateTime)dr["timeOfDeparture"], (DateTime)dr["timeOfArrival"], (int)dr["distance"], dr["pointOfDeparture"].ToString(), dr["pointOfArrival"].ToString());
                     }
                 }
             }
             catch (SqlException ex)
             {
                 Console.WriteLine(ex.Message);
             }
             finally
             {
                 conn.Close();
             }*/



            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "tcp:inwaysql.database.windows.net,1433",
                    UserID = "rkhusnut",
                    Password = "Asilvertopmustbe1",
                    InitialCatalog = "InWaySQL"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
                    sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                    sb.Append("JOIN [SalesLT].[Product] p ");
                    sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        

            return null;
        }
    }
}
