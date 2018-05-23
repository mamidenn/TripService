using System.Collections.Generic;

namespace TripService
{
    public interface IGetsTrips
    {
        List<Trip> GetTripsByUser(User user);
    }
}