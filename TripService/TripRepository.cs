using System.Collections.Generic;

namespace TripService
{
    public class TripRepository : IGetsTrips
    {
        public List<Trip> GetTripsByUser(User user)
        {
            return TripDao.FindTripsByUser(user);
        }
    }
}