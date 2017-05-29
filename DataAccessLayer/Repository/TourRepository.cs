using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public List<Tour> GetWaybillsOfDriver(int driverId)
        {

            var context = _context.Create();
            var conn = (SqlConnection)context;

            var cmdGetWaybills = new SqlCommand("select t.tourId, t.timeOfDeparture, t.timeOfArrival, t.Distance, departure.name, arrival.name from Waybill w " +
                                            "join tour t on t.tourId = w.tourId " +
                                            "join city departure on departure.cityId = t.pointOfDepartureId " +
                                            "join city arrival on arrival.cityId = t.pointOfArrivalId" +
                                            " where w.driverId =" + driverId.ToString(), conn);

            List<Tour> tours = new List<Tour>();

            try
            {
                using (var dr = cmdGetWaybills.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Tour tour = new Tour();

                        int tourId = (int)dr["tourId"];
                        DateTime timeOfDeparture = (DateTime) dr["timeOfDeparture"];
                        DateTime timeOfArrival = (DateTime)dr["timeOfArrival"];
                        int distance = (int)dr["distance"];
                        string pointOfDeparture = (string) dr["pointOfDeparture"];
                        string pointOfArrival = (string)dr["pointOfArrival"];

                        tour.TourId = tourId;
                        tour.TimeOfDeparture = timeOfDeparture;
                        tour.TimeOfArrival = timeOfArrival;
                        tour.Distance = distance;
                        tour.PointOfDeparture = pointOfDeparture;
                        tour.PointOfArrival = pointOfArrival;

                        tours.Add(tour);

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

            return tours;
        }




    }
}
