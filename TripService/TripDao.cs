using System.Collections.Generic;
using TripService.Exceptions;

namespace TripService
{
    public class TripDao
    {
        public static List<Trip> FindTripsByUser(User user)
        {
            throw new DependencyCallDuringUnitTestException();
        }
    }
}