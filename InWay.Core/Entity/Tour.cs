using System;

namespace InWay.Core.Entity
{
    public class Tour
    {
        public int TourId { get; private set; }
        public DateTime? TimeOfDeparture { get; private set; }
        public DateTime? TimeOfArrival { get; private set; }
        public int Distance { get; private set; }
        public string PointOfDeparture { get; private set; }
        public string PointOfArrival { get; private set; }

        public Tour(DateTime? timeOfDeparture, DateTime? timeOfArrival, int distance, string pointOfDeparture, string pointOfArrival)
        {

            if (timeOfDeparture == null)
                throw new ArgumentNullException("TimeOfDeparture can't be null");
            TimeOfDeparture = timeOfDeparture;
            if (timeOfArrival == null)
                throw new ArgumentNullException("Time of arrival can't be null");
            TimeOfArrival = timeOfArrival;
            Distance = distance;
            if (pointOfDeparture == null)
                throw new ArgumentNullException("PointOfDeparture can't be null");
            PointOfDeparture = pointOfDeparture;
            if (pointOfArrival == null)
                throw new ArgumentNullException("Point of arrival can't be null");
            PointOfArrival = pointOfArrival;
        }

        public void SetTourId(int tourId)
        {
            TourId = tourId;
        }

    }
}
